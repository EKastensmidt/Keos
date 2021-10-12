using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudThrowerBehaviour : Projectile
{
    [SerializeField] private ParticleSystem _particleSystem;
    private PlayerController _playerController;
    private static float hitCd;
    private float hitRate = 0.15f;
    private float soundCd;
    private float soundRate = 0.25f;
    private bool isPlayingSound = true;
    [SerializeField] private float destroyTime = 5f;
    private void Start()
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 segment = mouseOnScreen - (Vector2)transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, segment);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        if (soundCd < Time.time && isPlayingSound)
        {
            SoundManagerScript.PlaySound("FlameThrower");
            soundCd = Time.time + soundRate;
            isPlayingSound = true;
        }

        if (!_playerController.IsPlaying)
        {
            isPlayingSound = false;
            _particleSystem.Stop();
            Destroy(gameObject, destroyTime);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Ground")
        {
            //Instantiate(Resources.Load("MudPrefab") as GameObject, other.transform.position, Quaternion.identity);
        }
    }
}
