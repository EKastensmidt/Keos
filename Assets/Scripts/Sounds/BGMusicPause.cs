using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicPause : MonoBehaviour
{
    private void Awake()
    {
        if (BGMusicScript.Instance != null)
        {
            Destroy(BGMusicScript.Instance.gameObject);
        }
    }
}
