using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour {

    public PlayerBehaviour player;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if(collision.collider.name == "Obstacle")
        {
            Debug.Log("Hit");
            player.enabled = false;
        }

    }

}
