using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject lose;
    public KeyCode quit;
    bool isAlive;
    public Text score;
    public Text maxScore;
    public float maxVal;
    public float commonVal;

    
    // Use this for initialization
	void Start () {
        if(lose != null)
        {
            lose.SetActive(false);
        }
        isAlive = true;
        maxScore.enabled = false;
        commonVal = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //look for other solution, time uses the time that 
        //Passes since the game starts
        if(isAlive)
        {
            commonVal = Time.time;
            score.text=("Score: " + (int)commonVal);
            maxVal = commonVal;       
        }
        else
        {
            commonVal = 0;
            score.enabled = false;
            maxScore.enabled = true;
            maxScore.text= ("Score: " + (int)maxVal);
            
        }
	}
    
    public void Quit()
    {
        Application.Quit();
    }

    public void ActivateUI()
    {
        lose.SetActive(true);
        isAlive = false;
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
