using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour {

    public Vector3 scaler;
    public float xValue, yValue, zValue;

    public float delay;
    float startingDelay;

	// Use this for initialization
	void Start () {
        xValue = Random.Range(1, 12);
        yValue = 2;
        zValue = Random.Range(1, 4);
        scaler = new Vector3(xValue, yValue, zValue);
        transform.localScale = scaler;

        startingDelay = delay;

    }

    private void Update()
    {
        delay -= Time.deltaTime;
        if(delay<=0)
        {
            Destroy(gameObject);
        }
    }

}
