﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBallBehaviour : Projectile
{
    private Rigidbody2D rb;
    private Vector3 direction;

    private int bounceCount;
    [SerializeField] private int maxBounces = 4, damageAmplifier = 3;
    private static int amplifiedDamage;

    private void Start()
    {
        amplifiedDamage = Damage;
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * 2.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceCount++;
        amplifiedDamage += damageAmplifier;
        if (bounceCount >= maxBounces)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 10)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(amplifiedDamage);
            }
        }
    }
}