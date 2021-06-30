using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemyHitSound, flameThrowerSound, fireBallSound, jumpSound;
    private static AudioSource audioSource;

    void Start()
    {
        enemyHitSound = Resources.Load<AudioClip>("Sounds/SFX/EnemyHit");
        flameThrowerSound = Resources.Load<AudioClip>("Sounds/SFX/FlameThrower");
        fireBallSound = Resources.Load<AudioClip>("Sounds/SFX/FireBall");
        jumpSound = Resources.Load<AudioClip>("Sounds/SFX/Jump");


        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "EnemyHit":
                audioSource.PlayOneShot(enemyHitSound);
                break;
            case "FlameThrower":
                audioSource.PlayOneShot(flameThrowerSound);
                break;
            case "FireBall":
                audioSource.PlayOneShot(fireBallSound);
                break;
            case "Jump":
                audioSource.PlayOneShot(jumpSound);
                break;
        }
    }
}
