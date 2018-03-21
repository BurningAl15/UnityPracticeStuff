using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBehaviour : MonoBehaviour {

    /* Values could be in keys or positions
      
     0-> Up
     1-> Down
     2-> Right
     3-> Left
     
     */  
     

    public KeyCode[] keys;

    public GameObject bullet;
    public Transform[] positions;

    public int horizontalDir;
    public int verticalDir;

    public bool pressed;

    public float delay;
    public bool active;
	// Use this for initialization
	void Start () {
        horizontalDir = 0;
        verticalDir = 0;
        pressed = false;
        active = false;
	}

    // Update is called once per frame
    void Update() {
        if (!active)
        {
            direction();
        }
        else
        {
            delay -= Time.deltaTime;
            if(delay<=0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


    }


    void direction()
    {
        Quaternion quat;
        Vector3 pos;
        
        if (Input.GetKeyDown(keys[0]))
        {
            pos = new Vector3(positions[0].transform.position.x, positions[0].transform.position.y, positions[0].transform.position.z);
            quat = new Quaternion(0f, 0f, 0f, 180f);
            Instantiate(bullet, pos,quat);
            horizontalDir = 0;
            verticalDir = 1;
        }
        else if (Input.GetKeyDown(keys[1]))
        {
            pos = new Vector3(positions[1].transform.position.x, positions[1].transform.position.y, positions[1].transform.position.z);
            quat = new Quaternion(540f, 0f, 0f, 180f);
            Instantiate(bullet, pos,quat);
            horizontalDir = 0;
            verticalDir = -1;
        }
        else if (Input.GetKeyDown(keys[2]))
        {
            pos = new Vector3(positions[2].transform.position.x, positions[2].transform.position.y, positions[2].transform.position.z);
            quat = new Quaternion(0f, 0f, -180f, 180f);

            Instantiate(bullet, pos,quat);
            horizontalDir = 1;
            verticalDir = 0;
        }
        else if (Input.GetKeyDown(keys[3]))
        {
            pos = new Vector3(positions[3].transform.position.x, positions[3].transform.position.y, positions[3].transform.position.z);
            quat = new Quaternion(0f, 0f, 180f, 180f);

            Instantiate(bullet, pos,quat);
            horizontalDir = -1;
            verticalDir = 0;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Enemy"))
        {
            active = true;
        }
    }

}
