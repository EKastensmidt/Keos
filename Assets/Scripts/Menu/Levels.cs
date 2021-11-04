using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutorial;
    public GameObject levelUno;
    public GameObject levelDos;
    public GameObject mainMenu;
    
    public void Level1()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level_4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level_5");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level_6");
    }
    public void Level7()
    {
        SceneManager.LoadScene("Level_7");
    }
    public void Level8()
    {
        SceneManager.LoadScene("Level_8");
    }
    public void Level9()
    {
        SceneManager.LoadScene("Level_9");
    }
    public void Bossfight1()
    {
        SceneManager.LoadScene("BossFight_1");
    }
    public void Bossfight2()
    {
        SceneManager.LoadScene("BossFight_2");
    }
    public void SecretLevel1()
    {
        SceneManager.LoadScene("SecretLevel_1");
    }
    public void SecretLevel2()
    {
        SceneManager.LoadScene("SecretLevel_2");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Tutorial2()
    {
        SceneManager.LoadScene("Tutorial_2");
    }
    public void Tutorial3()
    {
        SceneManager.LoadScene("Tutorial_3");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
