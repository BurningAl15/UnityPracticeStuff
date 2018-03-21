using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviours : MonoBehaviour {

    Rigidbody rgb;

    public float speed;
    public float delay;
    float startingDelay;
    public int dir;

    // Use this for initialization
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        startingDelay = delay;

    }

	// Update is called once per frame
	void Update () {
        //delay -= Time.deltaTime;
        //if(delay<=0)
        //{
        //    dir *= -1;
        //    delay = startingDelay;
        //}
        Vector3 move;
        move = new Vector3(speed * dir, rgb.velocity.y, rgb.velocity.z);
        rgb.velocity = move;
    }


    void Move()
    {
        Vector3 move;
        move = new Vector3(speed * dir, rgb.velocity.y, rgb.velocity.z);
        rgb.velocity = move;
    }
}
