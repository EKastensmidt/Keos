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
        if (CurrHealth != Previoushealth)
        {
            Previoushealth = CurrHealth;
            StartCoroutine(HitEffect());
        }

        if (CurrHealth <= 0)
        {
            platformRb.gravityScale += 1;
            Destroy(gameObject);
        }
    }

}
