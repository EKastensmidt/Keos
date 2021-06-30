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
            }
        }
    }
}
