using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private ParticleSystem deathExplotion;
    public int Damage { get => damage; set => damage = value; }

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
        OnDeath();
    }

    private void OnDeath()
    {
        if (deathExplotion != null)
            Instantiate(deathExplotion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
