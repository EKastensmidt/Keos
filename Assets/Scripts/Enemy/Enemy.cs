﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currHealth;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    private SpriteRenderer myRenderer;
    private float hitTimer = 0.1f;
    private int previoushealth;
    private Material auxMaterial;
    private Color myColor;
    [SerializeField] private GameObject damagePopup;
    [SerializeField] private float damagePopupOffset = 5f;
    [SerializeField] private ParticleSystem deathParticles;

    private bool isBurned = false;
    private bool burnEffect = true;
    private GameObject burnParticles;
    private GameObject burnParticlesObject = null;

    public int CurrHealth { get => currHealth; set => currHealth = value; }
    public int Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public int Previoushealth { get => previoushealth; set => previoushealth = value; }
    public SpriteRenderer MyRenderer { get => myRenderer; set => myRenderer = value; }
    public int MaxHealth { get => maxHealth; }
    public ParticleSystem DeathParticles { get => deathParticles; set => deathParticles = value; }
    public bool IsBurned { get => isBurned; }

    void Awake()
    {
        currHealth = maxHealth;
        previoushealth = currHealth;
        myRenderer = GetComponent<SpriteRenderer>();
        myColor = myRenderer.color;
        burnParticles = Resources.Load("Particles/BurnEffect") as GameObject;

    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void Update()
    {
        CheckStatusEffects();
    }

    public IEnumerator HitEffect()
    {
        myRenderer.color = Color.red;
        yield return new WaitForSeconds(hitTimer);
        myRenderer.color = myColor;
    }

    public virtual void TakeDamage(int damage)
    {
        currHealth -= damage;
        DamagePoints(damage);
        if (CurrHealth != Previoushealth)
        {
            Previoushealth = CurrHealth;
            StartCoroutine(HitEffect());
        }

        if (currHealth <= 0)
        {
            if (deathParticles != null)
            {
                Instantiate(deathParticles, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    public void DamagePoints(int damage)
    {
        GameObject damagePoints = Instantiate(damagePopup, transform.position, Quaternion.identity);
        damagePoints.GetComponent<TextMeshPro>().SetText(damage.ToString());
        SoundManagerScript.PlaySound("EnemyHit");
    }

    public void ApplyStatusEffect(DamageType damageType, float duration, int damage = 1, float damageInterval = 0.1f)
    {
        switch (damageType)
        {
            case DamageType.fire:
                burnDuration = duration;
                burnInterval = damageInterval;
                burnDamage = damage;
                isBurned = true;
                burnParticlesObject = Instantiate(burnParticles, transform.position, Quaternion.identity, transform);
                StartCoroutine(BurnEffectDuration(duration));
                break;

        }
    }

    int burnDamage = 0;
    float burnDuration = 0;
    float burnInterval = 0;
    IEnumerator ApplyBurnEffect(int burnDamage, float interval)
    {
        if (burnEffect)
        {
            TakeStatusEffectDamage(burnDamage);
            burnEffect = false;
            yield return new WaitForSeconds(interval);
            burnEffect = true;
        }
    }

    public virtual void TakeStatusEffectDamage(int damage)
    {
        currHealth -= damage;
        DamagePoints(damage);
        if (CurrHealth != Previoushealth)
        {
            Previoushealth = CurrHealth;
            StartCoroutine(HitEffect());
        }

        if (currHealth <= 0)
        {
            if (deathParticles != null)
            {
                Instantiate(deathParticles, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    private void CheckStatusEffects()
    {
        if (IsBurned)
            StartCoroutine(ApplyBurnEffect(burnDamage,burnInterval));
    }

    IEnumerator BurnEffectDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(burnParticlesObject);
        isBurned = false;
    }
}
