using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossProjectileAttack : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private GameObject projectile;
    private float auxAttackSpeed;

    private void Start()
    {
        auxAttackSpeed = attackSpeed;
    }
    void Update()
    {
        attackSpeed -= Time.deltaTime;
        if (attackSpeed < 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            attackSpeed = auxAttackSpeed;
        }
    }
}
