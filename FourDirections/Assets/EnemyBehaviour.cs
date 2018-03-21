using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    Rigidbody2D rgb;
    public float speed;
    public int horizontalDir;
    public int verticalDir;

    public int type;


	// Use this for initialization
	void Start () {
        rgb = GetComponent<Rigidbody2D>();
        type = FindObjectOfType<EnemyInstantiator>().type;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    public void Move()
    {

        switch(type)
        {
            //Up,down,right,left
            default:
            case 0:
                horizontalDir = 0;
                verticalDir = -1;

                break;
            case 1:
                horizontalDir = 0;
                verticalDir = 1;

                break;
            case 2:

                horizontalDir = -1;
                verticalDir = 0;

                break;
            case 3:
                horizontalDir = 1;
                verticalDir = 0;

                break;
        }
        rgb.velocity = new Vector2(speed * horizontalDir, speed * verticalDir);
    }
    


}
