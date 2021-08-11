using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemyHitSound, flameThrowerSound, fireBallSound, jumpSound, elementSelectSound, consumableSound,
        windDashSound, playerHitSound;
    private static AudioSource audioSource;

    void Start()
    {
        InitiateSounds();
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
            case "ElementSelect":
                audioSource.PlayOneShot(elementSelectSound);
                break;
            case "Consumable":
                audioSource.PlayOneShot(consumableSound);
                break;
            case "WindDash":
                audioSource.PlayOneShot(windDashSound);
                break;
            case "PlayerHit":
                audioSource.PlayOneShot(playerHitSound);
                break;
        }
    }
    private void InitiateSounds()
    {
        enemyHitSound = Resources.Load<AudioClip>("Sounds/SFX/EnemyHit");
        flameThrowerSound = Resources.Load<AudioClip>("Sounds/SFX/FlameThrower");
        fireBallSound = Resources.Load<AudioClip>("Sounds/SFX/FireBall");
        jumpSound = Resources.Load<AudioClip>("Sounds/SFX/Jump");
        elementSelectSound = Resources.Load<AudioClip>("Sounds/SFX/ElementSelect");
        consumableSound = Resources.Load<AudioClip>("Sounds/SFX/Consumable");
        windDashSound = Resources.Load<AudioClip>("Sounds/SFX/WindDash"); 
        playerHitSound = Resources.Load<AudioClip>("Sounds/SFX/PlayerHit");
    }
}
