using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusEffect : MonoBehaviour {

    //MagnusConstant must be in a range between -0.1f and 0.1 (prove and see the effect)
    public float magnusConstant = 1f;
    private Rigidbody rgb;

	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rgb.AddForce( magnusConstant* Vector3.Cross(rgb.angularVelocity, rgb.velocity));
	}
}
