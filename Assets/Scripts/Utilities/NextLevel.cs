using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private bool isSecret = false;
  
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
                    if (isSecret)
                        SceneManager.LoadScene("SecretLevel_1");
                    else
                        SceneManager.LoadScene("Level_3");
                    break;
                case "SecretLevel_1":
                    SceneManager.LoadScene("Level_3");
                    break;
                case "Level_3":
                    SceneManager.LoadScene("BossFight_1");
                    break;
                case "BossFight_1":
                    SceneManager.LoadScene("Tutorial_2");
                    break;
                case "Tutorial_2":
                    SceneManager.LoadScene("Level_4");
                    break;
                case "Level_4":
                    SceneManager.LoadScene("Level_5");
                    break;
                case "Level_5":
                    if (isSecret)
                        SceneManager.LoadScene("SecretLevel_2");
                    else
                        SceneManager.LoadScene("Level_6");
                    break;
                case "SecretLevel_2":
                    SceneManager.LoadScene("Level_6");
                    break;
                case "Level_6":
                    SceneManager.LoadScene("BossFight_2");
                    break;
                case "BossFight_2":
                    SceneManager.LoadScene("Tutorial_3");
                    break;
                case "Tutorial_3":
                    SceneManager.LoadScene("Level_7");
                    break;
            }
        }
    }
}
