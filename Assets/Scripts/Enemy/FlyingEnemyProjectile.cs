using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    private Rigidbody2D rb;
    private Vector3 direction;

    [SerializeField] private ParticleSystem deathExplotion;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = (GameObject.Find("Maguito").transform.position - transform.position).normalized;
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            PlayerManager player = collision.gameObject.GetComponent<PlayerManager>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
        Ondeath();
    }

    void Ondeath()
    {
        Instantiate(deathExplotion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
