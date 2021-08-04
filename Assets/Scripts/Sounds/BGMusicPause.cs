using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicPause : MonoBehaviour
{
    private void Start()
    {
        BGMusicScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}
