using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour {

    Rigidbody rgb;

    public int type;

    [SerializeField]
    float rotX, rotY, rotZ;

    [SerializeField]
    float actX, actY, actZ;

    public float delay;
    float startingDelay;

    //

    public float speed;
    public float test1, test2;
    // Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody>();

        if(type==0)
        { 
        rotX = Random.Range(10f, 180f);
        rotY = Random.Range(10f, 180f);
        rotZ = Random.Range(10f, 180f);

        actX = Random.Range(0,2);
        actY= Random.Range(0, 2);
        actZ=Random.Range(0,2);

        startingDelay = delay;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(type==0)
        { 
            delay -= Time.deltaTime;
            if(delay<=0)
            {
                rotX = Random.Range(10f, 180f);
                rotY = Random.Range(10f, 180f);
                rotZ = Random.Range(10f, 180f);

                actX = Random.Range(0, 2);
                actY = Random.Range(0, 2);
                actZ = Random.Range(0, 2);

                delay=startingDelay;
            }

            rgb.AddTorque(rotX*actX*10,rotY*actY*10, rotZ*actZ*10);
        }
        Move();
	}

    void Move()
    {
        
        if(Mathf.Abs( Input.GetAxis("Horizontal"))>=0)
        {
            test1 = Input.GetAxis("Horizontal") * speed;
        }
        else if(Mathf.Abs( Input.GetAxis("Vertical")) >= 0)
        {
            test2 = Input.GetAxis("Vertical") * speed;
        }
        else
        {
            test1 =test2= 0f;
        }

        rgb.velocity = new Vector3(test1, 0f, test2);

    }
}
