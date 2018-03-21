using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resizeTerrain : MonoBehaviour {
    Vector3 scale;
	// Use this for initialization
	void Start () {
        scale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        scale.x = 90f;
        scale.z = 120f;
        transform.localScale = scale;
	}
}
