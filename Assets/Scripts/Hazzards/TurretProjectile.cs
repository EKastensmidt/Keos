using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private int damage = 20;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
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
        Destroy(this.gameObject);
    }
}
