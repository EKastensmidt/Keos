using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Jugar;
  
    

    public void PlayGame()
    {
        SceneManager.LoadScene("Levels");

    }


    public void QuitGame()
    {
        Application.Quit();
    }
}

