using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardTurret : MonoBehaviour
{
    [SerializeField] private GameObject emitter, projectile;
    [SerializeField] private float fireRate = 1, startTime = 0;
    private float fireCD;
    
    void Start()
    {
        
    }

    void Update()
    {
        startTime -= Time.deltaTime;
        if (startTime <= 0)
        {
            if (fireCD < Time.time)
            {
                GameObject firedProjectile = Instantiate(projectile, emitter.transform.position, Quaternion.identity);
                firedProjectile.transform.rotation = emitter.transform.rotation;
                fireCD = Time.time + fireRate;
            }
        }
    }
}
