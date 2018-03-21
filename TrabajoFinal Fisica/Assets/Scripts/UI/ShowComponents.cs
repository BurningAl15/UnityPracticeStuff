using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowComponents : MonoBehaviour {
    //private SpherePhysics sphere;
    public Text text1;
   
    // Use this for initialization
    void Start () {
        //sphere = FindObjectOfType<SpherePhysics>();
        text1 = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        //text1.text = "" + sphere.rgb.mass + " / " + Physics.gravity;
    }
}
