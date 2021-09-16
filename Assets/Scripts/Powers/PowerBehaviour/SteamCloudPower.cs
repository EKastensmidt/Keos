using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamCloudPower : Projectile
{
    [SerializeField] private ParticleSystem _particleSystem;
    private PlayerController _playerController;
    private Collider2D col;

    private float soundCd;
    private float soundRate = 0.25f;
    private bool isPlayingSound = true;

    void Start()
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseOnScreen;

        if (soundCd < Time.time && isPlayingSound)
        {
            SoundManagerScript.PlaySound("Steam");
            soundCd = Time.time + soundRate;
            isPlayingSound = true;
        }

        if (!_playerController.IsPlaying)
        {
            isPlayingSound = false;
            _particleSystem.Stop();
            col.enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
