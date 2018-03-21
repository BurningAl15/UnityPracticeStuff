using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartScene : MonoBehaviour {
    public string nombre;

    public void restart()
    {
        SceneManager.LoadScene(nombre);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
