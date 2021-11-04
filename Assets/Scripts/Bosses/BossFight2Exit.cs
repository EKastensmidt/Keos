using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight2Exit : MonoBehaviour
{
    [SerializeField] private GameObject BGMusic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.skipDialogue = false;
        BGMusic.gameObject.GetComponent<AudioSource>().Stop();
        Destroy(BGMusicScript.Instance);
    }
}
