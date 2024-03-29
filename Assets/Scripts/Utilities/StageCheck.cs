﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCheck 
{
    public static void Check(string sceneName)
    {
        switch (sceneName)
        {
            case "Tutorial":
            case "Level_1":
            case "Level_2":
            case "Level_3":
            case "SecretLevel_1":
                GameManager.IsBossFight = false;
                GameManager.IsWaterUnlocked = false;
                GameManager.IsEarthUnlocked = false;
                break;
            case "BossFight_1":
                GameManager.IsBossFight = true;
                GameManager.IsWaterUnlocked = false;
                GameManager.IsEarthUnlocked = false;
                break;
            case "Tutorial_2":
            case "Level_4":
            case "Level_5":
            case "Level_6":
            case "SecretLevel_2":
                GameManager.IsBossFight = false;
                GameManager.IsWaterUnlocked = true;
                GameManager.IsEarthUnlocked = false;
                break;
            case "BossFight_2":
                GameManager.IsBossFight = true;
                GameManager.IsWaterUnlocked = true;
                GameManager.IsEarthUnlocked = false;
                break;
            case "Tutorial_3":
            case "Level_7":
            case "Level_8":
            case "Level_9":
            case "SecretLevel_3":
                GameManager.IsBossFight = false;
                GameManager.IsWaterUnlocked = true;
                GameManager.IsEarthUnlocked = true;
                break;
            case "BossFight_3":
                GameManager.IsBossFight = true;
                GameManager.IsWaterUnlocked = true;
                GameManager.IsEarthUnlocked = true;
                break;
        }
    }

    public static void SceneInputs()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SceneManager.LoadScene("BossFight_2");
            }
            else
                SceneManager.LoadScene("Tutorial");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                SceneManager.LoadScene("Tutorial_3");
            }
            else
                SceneManager.LoadScene("Level_1");
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SceneManager.LoadScene("Level_7");
            }
            else
                SceneManager.LoadScene("Level_2");
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SceneManager.LoadScene("Level_8");
            }
            else
                SceneManager.LoadScene("Level_3");
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SceneManager.LoadScene("Level_9");
            }
            else
                SceneManager.LoadScene("BossFight_1");
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SceneManager.LoadScene("BossFight_3");
            }
            else
                SceneManager.LoadScene("Tutorial_2");
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            SceneManager.LoadScene("Level_4");
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            SceneManager.LoadScene("Level_5");
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            SceneManager.LoadScene("Level_6");
        }
    }
}
