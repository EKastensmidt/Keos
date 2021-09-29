using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : Projectile
{
    [SerializeField] private float _speed;
    [SerializeField] private float knockbackForce = 2f;
    [SerializeField] private ParticleSystem deathExplotion;
    public float Speed { get => _speed; }

    private Rigidbody2D rb;
    private Vector3 direction;

    private ParticleSystem metalCrateSparks;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        GameObject metalCrate = Resources.Load("Particles/MetalCrateSparks") as GameObject;
        metalCrateSparks = metalCrate.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        rb.velocity = direction * _speed;
        transform.Rotate(Vector3.forward * 3);
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D enemyrb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (collision.gameObject.layer == 10)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
                if (enemyrb != null)
                {
                    Vector2 difference = (transform.position - collision.gameObject.transform.position).normalized;
                    Vector2 force = difference * knockbackForce;
                    enemyrb.AddForce(-force, ForceMode2D.Impulse);
                }
            } 
        }

        else if (collision.gameObject.layer == 16)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
        
        else if (enemyrb != null)
        {
            Vector2 difference = (transform.position - collision.gameObject.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            enemyrb.AddForce(-force, ForceMode2D.Impulse);
        }

        if (collision.gameObject.layer == 21)
        {
            SoundManagerScript.PlaySound("MetalHit");
            Instantiate(metalCrateSparks, transform.position, Quaternion.identity);
        }
        OnDeath();
    }

    private void OnDeath()
    {
        Instantiate(deathExplotion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
