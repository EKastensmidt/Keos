using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicPause : MonoBehaviour
{
    private void Start()
    {
        if (BGMusicScript.Instance != null)
        {
            BGMusicScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
        }
    }
}
