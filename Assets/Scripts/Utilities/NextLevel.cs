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
            if(currScene == "Tutorial")
            {
                currScene = "Level_1";
                SceneManager.LoadScene("Level_1");
            }
        }
    }
}
