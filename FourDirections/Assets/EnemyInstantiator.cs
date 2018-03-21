using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiator : MonoBehaviour {

    public GameObject enemy;
    public float delay;
    float startingTime;
    public int type;
    public Transform[] positions;

	// Use this for initialization
	void Start () {
        type = Random.Range(0, 4);
        
        startingTime = delay;
    }
	
	// Update is called once per frame
	void Update () {

        delay -= Time.deltaTime;
        if(delay<=0)
        {
            type = Random.Range(0, 4);
            Caller();
            delay = startingTime;
        }

	}

    void Caller()
    {
        switch (type)
        {
            //Up,down,right,left
            default:
            case 0:
                Instantiate(enemy, positions[0]);

                break;
            case 1:
                Instantiate(enemy, positions[1]);

                break;
            case 2:
                Instantiate(enemy, positions[2]);

                break;
            case 3:
                Instantiate(enemy, positions[3]);

                break;
        }
        
    }

}
