using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class worldGen : MonoBehaviour {

    //ints and floats.
    float spawnDistanceX = 0;
    float speedGround = 0;
    float distanceToDespawn = -20, distanceToSpawn = 40;//sorry magic number
    int spawnGeneric = 1;

    //gameObjects
    public GameObject[] platforms;
    public GameObject balloonObj;
    GameObject lastaddedPlatform;
    //scripts
    balloonControler balloonConScr;
    List<GameObject> platformsObj = new List<GameObject>();
   

	// Use this for initialization
	void Start () {
        balloonConScr = balloonObj.GetComponent<balloonControler>();
        spawnDistanceX = distanceToSpawn;
        for (int i=-10;i<10;i++)
        {
            GameObject setBlockObj = Instantiate(platforms[0]) as GameObject;
            setBlockObj.name = "platform";
            setBlockObj.transform.SetParent(this.transform);
            setBlockObj.transform.position = new Vector3(i * 3, -3.5f, 0);
            platformsObj.Add(setBlockObj);
            //give the last spawn Cordination
            lastaddedPlatform = setBlockObj;
            
        }
	}
	// Update is called once per frame
    //random kan je een handje helpen maar het moet wel goed uitgebalaceerd zijn.
    //een foreach voor het bewegen van het object.
	void Update () {
        if (!balloonConScr.getGameOver)
        {
            moveObjects();
            SetObjects();
        }
	}
    void moveObjects()
    {
        speedGround = 2*Time.deltaTime;
        for (int i=0; i<platformsObj.Count;i++)
        {
          //move the objects. 
            if (platformsObj[i].transform.position.x-0.1 < distanceToDespawn)
            {
                platformsObj[i].SetActive(false);
            }
            else
            {
                platformsObj[i].transform.Translate(Vector3.left * speedGround);
            }
        }
    }
    void SetObjects()
    {
        int spawnNr = 0;
        GameObject lastObject = platformsObj[0];
        for (int i = 0; i < platformsObj.Count; i++)
        {
            if(lastObject.transform.position.x<=platformsObj[i].transform.position.x && platformsObj[i].activeInHierarchy)
            {
                //the object that is the farest of us all.
                lastObject = platformsObj[i];
            }
        }
        //objects are random spawnt by this spawner.
        if(lastaddedPlatform.transform.position.x + lastObject.transform.position.x < spawnDistanceX)
        {
            //new object is spawend.
            if (spawnGeneric < 1)
            {
                spawnNr = Random.Range(1, 5);
                spawnGeneric = Random.Range(1,4);
            }
            else
            {
                spawnNr = 0;
                spawnGeneric--;
            }
            switch(spawnNr)
            {
                case 0:
                    spawnObject("platform", -3.5f, spawnNr,3);
                break;
                case 1:
                    spawnObject("hill", -2.75f, spawnNr,3);
                break;
                case 2:
                    spawnObject("mountain", -2.75f, spawnNr, 3);
                break;
                case 3:
                    spawnObject("clouds", -3.5f, spawnNr, 3);
                break;
                case 4:
                    spawnObject("pit", -3.5f, spawnNr, 3);
               break;
            }
        }
    }
    void spawnObject(string name,float height,int spawNr,float distance)
    {
        //check object pooling.
      bool spawend = false;
        for (int i = 0; i < platformsObj.Count; i++)
        {
            if (platformsObj[i].activeInHierarchy == false && platformsObj[i].name == name)
            {
                spawend = true;
                platformsObj[i].SetActive(true);
                platformsObj[i].transform.position = new Vector3(lastaddedPlatform.transform.position.x +distance, height, 0);
                lastaddedPlatform = platformsObj[i];
                break;
            }
        }
        //no of it is active make a new one.
        if (!spawend)
        {
            GameObject newObject = Instantiate(platforms[spawNr]) as GameObject;
            newObject.name = name;
            newObject.transform.position = new Vector3(lastaddedPlatform.transform.position.x + distance, height, 0);
            platformsObj.Add(newObject);
            newObject.transform.SetParent(this.transform);
            lastaddedPlatform = newObject;
        }
    }
}
