using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowPosX : MonoBehaviour {
    private BallBehaviour sphere;
    Text text1;
    
    // Use this for initialization
	void Start () {
        sphere = FindObjectOfType<BallBehaviour>();
        text1 =GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //text1.text = "" + sphere.initialPos;
	}
}
