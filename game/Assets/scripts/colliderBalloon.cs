using UnityEngine;
using System.Collections;

public class colliderBalloon : MonoBehaviour {
    balloonControler balCon;
    public GameObject[] Gaps;
    public GameObject self;
    void Start()
    {
        balCon =self.GetComponent<balloonControler>();
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.gameObject.tag=="clouds")
        {
            if(balCon.SetGetBroken<6)
            {
                balCon.SetGetBroken += 1;
                Gaps[balCon.SetGetBroken-1].SetActive(true);
                Debug.Log("hit");
            }
        }
    }
}
