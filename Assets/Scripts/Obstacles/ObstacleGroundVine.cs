using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGroundVine : Enemy
{
    private int LockedDamage = 1;
    public override void TakeDamage(int damage)
    {
        CurrHealth -= LockedDamage;
        DamagePoints(LockedDamage);
        SoundManagerScript.PlaySound("EnemyHit");
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
