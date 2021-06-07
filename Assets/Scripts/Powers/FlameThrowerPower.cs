using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerPower : Projectile
{
    private PlayerController _playerController;
    private float hitCd;
    private float hitRate = 0.1f;

    private void Start()
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        if (!_playerController.IsPlaying)
        {
            Destroy(gameObject);
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == 10)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (hitCd <= Time.time)
            {
                enemy.CurrHealth -= Damage;
                hitCd = Time.time + hitRate;
            }
        }
    }
}
