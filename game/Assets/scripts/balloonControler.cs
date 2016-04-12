using UnityEngine;
using System.Collections;

public class balloonControler : MonoBehaviour {
    public GameObject gameController;
    ballonScript balloonConScr;
    Rigidbody2D rig;
    int Broken = 0;
    float penaltyAir = 0;
    public Collider2D BalloonCol,badtubCol;

    bool GameOver = false;
    [Range(0, 10)] public float MultiplieDamage;
    [Range(0, 10)] public float MultiplieDrag;
    [Range(0, 100)]public float MinDrags;
    [Range(0, 100)]public float MaxDrags;

    public int SetGetBroken
    {
        set
        {
            Broken = value;
        }
        get
        {
            return Broken;
        }
    }

    public bool getGameOver
    {
        get
        {
            return GameOver;
        }
    }
    float speed;
	// Use this for initialization
	void Start () {
        balloonConScr = gameController.GetComponent<ballonScript>();
        rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameOver)
        {
            balloonMoveUp();
        }
        else
        {
            rig.gravityScale = 0;
        }
	}
    void balloonMoveUp()
    {
        penaltyAir = Broken * MultiplieDrag;
        speed = 10 * Time.deltaTime;
        if (balloonConScr.GetActiveHotAir)
        {
            //active is omhoog.
            rig.drag = MinDrags+ penaltyAir* MultiplieDamage;
            rig.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
        else
        {
            rig.drag = MaxDrags- penaltyAir;
        }
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "ground")
        {
            GameOver = true;
        }
    }
}
