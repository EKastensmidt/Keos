using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : Projectile
{
    [SerializeField] private float _speed;
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
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
        Destroy(gameObject);
    }
}
