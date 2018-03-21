using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private BallBehaviour sphere;

    public Vector3 offset;
	// Use this for initialization
	void Start () {
        sphere = FindObjectOfType<BallBehaviour>();
        offset = transform.position - sphere.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = sphere.transform.position + offset;
	}
}
