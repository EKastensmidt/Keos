using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
    private float cd;
    private float timer = 0.15f;
    public FlameThrower(Transform Emmiter): base(Elements.fire, Elements.fire)
    {
        prefab = Resources.Load("FlameThrower") as GameObject;
        this.SpawnPoint = Emmiter;
    }

    public override void Execute()
    {   
        GameObject projectile = Instantiate(prefab, SpawnPoint.transform.position, Quaternion.identity, SpawnPoint);         
    }
}
