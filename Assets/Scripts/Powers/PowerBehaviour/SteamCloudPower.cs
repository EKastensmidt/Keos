using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamCloudPower : Projectile
{
    [SerializeField] private ParticleSystem _particleSystem;
    private PlayerController _playerController;
    private Collider2D col;

    void Start()
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseOnScreen;

        if (!_playerController.IsPlaying)
        {
            _particleSystem.Stop();
            col.enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
