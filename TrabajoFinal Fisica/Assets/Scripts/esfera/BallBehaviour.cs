using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    Rigidbody rgb;

    public Vector3 initialVelocity;
    public Vector3 initialW;

    float impulse=0;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();
        rgb.velocity = initialVelocity;
        rgb.angularVelocity = initialW;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButton(0))
        //{
        //    impulse += Time.deltaTime;
        //}
        //Debug.Log(impulse);
        //rgb.velocity = new Vector3(initialVelocity.x + impulse, initialVelocity.y + impulse, initialVelocity.z);

    }
}
