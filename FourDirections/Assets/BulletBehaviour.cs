using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    Rigidbody2D rgb;
    public float speed;
    PlayerBehaviour player;

    public int horizontal;
    public int vertical;

    public float delay;


    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerBehaviour>();
        rgb = GetComponent<Rigidbody2D>();
        horizontal = player.horizontalDir;
        vertical = player.verticalDir;

    }
	
	// Update is called once per frame
	void Update () {
        Move();

        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            speed = Random.Range(5, 10);
            Destroy(gameObject);
        }
    }

    void Move()
    {
        rgb.velocity = new Vector2(speed * horizontal, speed * vertical);
        //Debug.Log("" + rgb.velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
