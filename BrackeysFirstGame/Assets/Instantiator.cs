using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {

    public GameObject obstacle;

    public float delay;
    float startingDelay;
    Vector3 pos;
    public float xPos, yPos, zPos;

	// Use this for initialization
	void Start () {
        xPos = Random.Range(-5f, 5f);
        yPos = 1f;
        zPos = Random.Range(-20f, 25f);
        pos = new Vector3(xPos, yPos, zPos);
        obstacle.transform.position = pos;
        startingDelay = delay;	
	}
	
	// Update is called once per frame
	void Update () {

        delay -= Time.deltaTime;
        if(delay<=0)
        {
            Instantiate(obstacle);
            xPos = Random.Range(-5f, 5f);
            zPos = Random.Range(-20f, 25f);
            pos = new Vector3(xPos, yPos, zPos);
            obstacle.transform.position = pos;
            delay = startingDelay;
        }

	}
}
