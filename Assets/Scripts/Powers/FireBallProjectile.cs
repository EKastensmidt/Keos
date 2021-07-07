using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : Projectile
{
    [SerializeField] private float _speed;
    [SerializeField] private float knockbackForce = 2f;
    public float Speed { get => _speed; }

    private Rigidbody2D rb;
    private Vector3 direction;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
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
        else if (enemyrb != null)
        {
            Vector2 difference = (transform.position - collision.gameObject.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            enemyrb.AddForce(-force, ForceMode2D.Impulse);
        }
        Destroy(gameObject);
    }
}
