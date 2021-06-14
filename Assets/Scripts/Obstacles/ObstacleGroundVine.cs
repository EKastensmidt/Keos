using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGroundVine : Enemy
{
    public override void TakeDamage(int damage)
    {
        CurrHealth -= 1;
        if (CurrHealth != Previoushealth)
        {
            Previoushealth = CurrHealth;
            StartCoroutine(HitEffect());
        }

        if (CurrHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
