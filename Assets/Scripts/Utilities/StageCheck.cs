using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCheck : MonoBehaviour
{
    public static void Check(string sceneName)
    {
        switch (sceneName)
        {
            case "Tutorial":
            case "Level_1":
            case "Level_2":
                GameManager.IsWaterUnlocked = false;
                GameManager.IsEarthUnlocked = false;
                break;
            case "BossFight_1":
                GameManager.IsBossFight = true;
                GameManager.IsWaterUnlocked = false;
                GameManager.IsEarthUnlocked = false;
                break;
            case "Level_3":
                GameManager.IsWaterUnlocked = true;
                GameManager.IsEarthUnlocked = false;
                break;
        }
    }

    public static void SceneInputs()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene("Level_1");
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene("Level_2");
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            SceneManager.LoadScene("BossFight_1");
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene("Level_3");
        }
    }
}
