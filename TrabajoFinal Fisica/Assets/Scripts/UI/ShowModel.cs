using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour {
    private SpherePhysics sphere;
	
    // Use this for initialization
	void Start () {
        sphere = FindObjectOfType<SpherePhysics>();	
	}
	
	public void Text_Changed(string n)
    {
        double value = double.Parse(n);
        sphere.Speed = (float)value;
    }
}
