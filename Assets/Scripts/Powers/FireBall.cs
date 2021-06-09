﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
    private float spawnCd;
    private float spawnRate = 0.25f;
    public FireBall(Transform Emmiter) : base(Elements.fire, Elements.wind)
    {
        prefab = Resources.Load("FireBall") as GameObject;
        this.SpawnPoint = Emmiter;
    }

    public override void Execute()
    {
        if (spawnCd <= Time.time)
        {
            GameObject projectile = Instantiate(prefab, SpawnPoint.position, Quaternion.identity);
            spawnCd = Time.time + spawnRate;
        }
    }
}
