using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private string currScene;
    private void Start()
    {
        currScene = SceneManager.GetActiveScene().name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            switch (currScene)
            {
                case "Tutorial":
                    currScene = "Level_1";
                    break;
                case "Level_1":
                    currScene = "Level_2";
                    break;
                case "Level_2":
                    currScene = "BossFight_1";
                    break;
            }           
            SceneManager.LoadScene(currScene);
        }
    }
}
