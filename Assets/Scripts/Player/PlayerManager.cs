using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    private Rigidbody2D rb;
    private float knockbackForce = 4;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public HealthBar HealthBar { get => healthBar; set => healthBar = value; }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Heal(int heal)
    {
        int overHeal = currentHealth + heal;
        if (overHeal > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                TakeDamage(enemy.Damage);
            }
            Rigidbody2D enemyrb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyrb != null)
            {
                Vector2 difference = (transform.position - collision.gameObject.transform.position).normalized;
                Vector2 force = difference * knockbackForce;
                rb.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }
}
