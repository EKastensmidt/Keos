using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGroundVine : Enemy
{
    public override void Update()
    {
        base.Update();
        if(CurrHealth != Previoushealth)
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
