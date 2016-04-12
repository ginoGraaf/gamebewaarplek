using UnityEngine;
using System.Collections;

public class moveBackground : MonoBehaviour {
   public Material back;
    public GameObject balloonObj;
    balloonControler balloonScr;
    float speed;
	// Use this for initialization
	void Start () {
        balloonScr = balloonObj.GetComponent<balloonControler>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!balloonScr.getGameOver)
        {
            speed = 0.1f * Time.deltaTime;
            back.mainTextureOffset = new Vector2(back.mainTextureOffset.x + speed, 0);
        }
    }
}
