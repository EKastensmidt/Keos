using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardTurret : MonoBehaviour
{
    [SerializeField] private GameObject emitter, projectile;
    [SerializeField] private float fireRate = 1;
    private float fireCD;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (fireCD < Time.time)
        {
            GameObject firedProjectile = Instantiate(projectile, emitter.transform.position, Quaternion.identity);
            firedProjectile.transform.rotation = emitter.transform.rotation;
            fireCD = Time.time + fireRate;
        }
    }
}
