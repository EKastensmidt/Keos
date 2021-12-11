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
    private float hitTimer = 1f;
    private float hitCd;
    private bool isBubble = false;
    private float invincibilty = 0f;
    private SpriteRenderer renderer;

    private float bubbleRechargeTimer = 2.5f;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public HealthBar HealthBar { get => healthBar; set => healthBar = value; }
    public bool IsBubble { get => isBubble; set => isBubble = value; }

    private void Start()
    {
        BubblePower.Health = 3;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log(BubblePower.Health + "     " + bubbleRechargeTimer);
        //BUBBLE HEALTH TIMER RESTORE
        if (isBubble || BubblePower.Health == 3)
            bubbleRechargeTimer = 2.5f;
        else
            bubbleRechargeTimer -= Time.deltaTime;

        if(BubblePower.Health < 3 && bubbleRechargeTimer < 0)
        {
            BubblePower.HealthRestore();
            bubbleRechargeTimer = 2.5f;
        }

        //INVINCIBILITY FRAMES
        if(invincibilty > 0f)
        {
            invincibilty -= Time.deltaTime;
            int alpha = ((int) (Time.time * 1000 *2 )) % 512;
            if (alpha > 255) alpha = 512 - alpha;
            float alphaF = alpha / 256f;

            renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alphaF);
        } else renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1f);
    }

    public void TakeDamage(int damage)
    {
        if (isBubble)
        {
            BubblePower.TakeDamage(damage);
        }

        if (!IsBubble && invincibilty <= 0f && damage > 0)
        {
            invincibilty = hitTimer;
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            ScreenShake.instance.StartShake(0.2f, 0.1f);
            SoundManagerScript.PlaySound("PlayerHit");    
        }
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
        if (IsBubble && collision.gameObject.layer != 10)
        {
            SoundManagerScript.PlaySound("BubbleBounce");
        }

        if (collision.gameObject.layer == 10)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                TakeDamage(enemy.Damage);
                Rigidbody2D enemyrb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (enemyrb != null && enemy.Damage != 0)
                {
                    Vector2 difference = (transform.position - collision.gameObject.transform.position).normalized;
                    Vector2 force = difference * knockbackForce;
                    rb.AddForce(force, ForceMode2D.Impulse);
                    enemyrb.AddForce(-difference * knockbackForce, ForceMode2D.Impulse);
                }
            }   
        }

        if (collision.gameObject.layer == 20)
        {
            IsBubble = false;
        }
    }

}
