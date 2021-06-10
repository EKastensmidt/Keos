using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCielingVine : Enemy
{
    private Rigidbody2D platformRb;

    void Start()
    {
        platformRb = GetComponentInParent<Rigidbody2D>();
    }

    public override void FixedUpdate()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (CurrHealth <= 0)
        {
            platformRb.gravityScale += 1;

        }
    }
}
