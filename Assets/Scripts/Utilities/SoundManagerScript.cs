using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemyHitSound;
    private static AudioSource audioSource;

    void Start()
    {
        enemyHitSound = Resources.Load<AudioClip>("Sounds/SFX/EnemyHit");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "EnemyHit":
                audioSource.PlayOneShot(enemyHitSound);
                break;
        }
    }
}
