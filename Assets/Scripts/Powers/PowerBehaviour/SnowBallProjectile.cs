using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallProjectile : Projectile
{
    private static float timeScale = 0.2f;
    private static float maxScale = 0.5f;
    private static float damageScale = 0.05f;
    private static int defaultDamage;
    private static int progressiveDamage;
    private void Start()
    {
        defaultDamage = Damage;
        progressiveDamage = defaultDamage;
    }
    private void Update()
    {
        damageScale -= Time.deltaTime;
        Vector3 scale = transform.localScale;
        transform.Rotate(Vector3.forward * 1.5f);

        if (transform.localScale.x < maxScale)
        {
            scale = new Vector3(transform.localScale.x + timeScale * Time.deltaTime, transform.localScale.y + timeScale * Time.deltaTime);
        }

        if (damageScale < 0)
        {
            progressiveDamage += 1;
            damageScale = 0.05f;
        }

        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 16)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(progressiveDamage);
            }
        }
        Destroy(gameObject);
    }
}
