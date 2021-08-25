using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour
{
    private static BGMusicScript instance = null;
    public static BGMusicScript Instance
    {
        get { return instance; }
    }

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
