using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Tutorial":
                    SceneManager.LoadScene("Level_1");
                    break;
                case "Level_1":
                    SceneManager.LoadScene("Level_2");
                    break;
                case "Level_2":
                    SceneManager.LoadScene("BossFight_1");
                    break;
                case "BossFight_1":
                    SceneManager.LoadScene("Level_3");
                    break;
                case "Level_3":
                    SceneManager.LoadScene("Level_4");
                    break;
                case "Level_4":
                    SceneManager.LoadScene("Level_5");
                    break;
                case "Level_5":
                    SceneManager.LoadScene("BossFight_2");
                    break;
            }
        }
    }
}
