using UnityEngine;
using System.Collections;

public class ballonScript : MonoBehaviour {
    bool activeHotAir = false;
    public bool GetActiveHotAir
    {
        get
        {
            return activeHotAir;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyUp(KeyCode.Space))
        {
            if (!activeHotAir)
            {
                activeHotAir = true;
            }
            else
            {
                activeHotAir = false;
            }
        }
	}
    public void ButtonBalloonLift()
    {
        activeHotAir = !activeHotAir;
    }
}
