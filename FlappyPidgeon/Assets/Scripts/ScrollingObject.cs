using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    Rigidbody2D rgb;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        rgb.velocity = Vector2.right * Controller.instance.scrollSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(Controller.instance.gameOver)
        {
            rgb.velocity = Vector2.zero;
        }
        
	}
}
