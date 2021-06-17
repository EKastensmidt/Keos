using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerPower : Projectile
{
    [SerializeField] private ParticleSystem _particleSystem;
    private PlayerController _playerController;
    private float hitCd;
    private float hitRate = 0.2f;

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
        if (!_playerController.IsPlaying)
        {
            _particleSystem.Stop();
            Destroy(gameObject,1f);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == 10)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && hitCd <= Time.time)
            {
                enemy.TakeDamage(Damage);
                hitCd = Time.time + hitRate;
            }
        }
    }
}
