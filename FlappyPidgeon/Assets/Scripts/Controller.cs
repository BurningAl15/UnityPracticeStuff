using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Controller : MonoBehaviour {

    public GameObject gameOverText;
    public bool gameOver;
    public string nombre;
    public static Controller instance;

    private int score;
    public Text scoreText;

    //Movimiento hacia la izquierda
    public float scrollSpeed=-20f;

    private void Awake()
    {
        if(Controller.instance==null)
        {
            Controller.instance = this;
        }
        else if(Controller.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController ha sido instanciado por segunda vez. Esto no deberia pasar");
        }
    }

    public void BirdScore()
    {
        if (gameOver) return;

        score++;
        scoreText.text ="" + score;
        SoundSystem.instance.PlayCoin();
    }


    // Update is called once per frame
    void Update () {


        if (gameOver && Input.GetMouseButtonDown(0))
        {
            //Ambos son iguales
            SceneManager.LoadScene(nombre);
            //Se obtiene el nombre de la escena actual
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void BirdDie()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    private void OnDestroy()
    {
        if (Controller.instance == this)
            Controller.instance = null;
    }



}
