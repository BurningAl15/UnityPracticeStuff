using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int columnPoolSize = 5;
    private GameObject[] columns;

    public float columnMin = -2.9f;
    public float columnMax = 0.6f;
    private float spawnXPosition=8f;

    public GameObject columnPrefab;
    Vector2 objectPoolPosition = new Vector2(-14, 0);

    private float timeSinceLastSpawn;
    public float spawnRate;

    private int currentColumn=0;

    // Use this for initialization
	void Start () {
        columns = new GameObject[columnPoolSize];
        for(int i=0;i<columnPoolSize;i++)
        {
            columns[i] = Instantiate(columnPrefab,objectPoolPosition,Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;
        if(!Controller.instance.gameOver && timeSinceLastSpawn > spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }

	}
}
