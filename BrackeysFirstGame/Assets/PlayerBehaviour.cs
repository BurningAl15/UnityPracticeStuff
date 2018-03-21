using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    Rigidbody rgb;

    public float zSpeed;
    public float xSpeed;
    public int xDirection;
    public int zDirection;
    public KeyCode right;
    public KeyCode left;

    public KeyCode forward;
    public KeyCode back;

    GameManager manager;
    bool isAlive;
    public float delay;
    float startingDelay;

    bool isPlaying;
    
    // Use this for initialization
	void Start () {
        this.enabled = true;
        rgb = GetComponent<Rigidbody>();
        isAlive = true;
        manager = FindObjectOfType<GameManager>();
        startingDelay = delay;
        isPlaying = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            isPlaying = true;
        }
        if(!isPlaying)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            if (isAlive)
                Move();
            else
            {
                delay -= Time.deltaTime;
                if (delay <= 0)
                {
                    this.enabled = false;
                    GameManager.Restart();
                }
            }
        }

        
	}

    public void Right()
    {
        xDirection = 1;
    }

    public void Left()
    {
        xDirection = -1;
    }


    public void NoMove()
    {
        xDirection = 0;
    }

    void Move()
    {
        Vector3 move;

        if(Input.GetKey(right))
        {
            Right();
        }
        else if(Input.GetKey(left))
        {
            Left();
        }
        //if(Input.GetKeyDown(forward))
        //{
        //    zDirection = 1;
        //}
        //if(Input.GetKeyDown(back))
        //{
        //    zDirection = -1;
        //}

        bool xMove = Input.GetKeyUp(right) || Input.GetKeyUp(left);
        bool zMove = Input.GetKeyUp(forward) || Input.GetKeyUp(back);
        if (xMove || zMove)
        {
            NoMove();
            //zDirection = 0;
        }
        move = new Vector3(xSpeed * xDirection, rgb.velocity.y, /*zDirection**/ zSpeed);
        rgb.velocity = move;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag.Equals("Obstacle"))
    //    {
    //        manager.ActivateUI();
    //        isAlive = false;
           
    //    }
    //    if(other.tag.Equals("Portal"))
    //    {
    //        GameManager.Restart();
    //    }
    //}

}
