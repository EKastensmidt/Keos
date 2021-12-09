using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Rigidbody2D rb;
    private float waitTime = 0.5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        waitTime -= Time.deltaTime;
        if (waitTime < 0)
            rb.MovePosition(new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager maguito = collision.GetComponent<PlayerManager>();
        if (maguito != null)
        {
            maguito.TakeDamage(damage);
        }
    }
}
