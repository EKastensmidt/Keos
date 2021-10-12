using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudThrower : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
    public MudThrower(Transform Emmiter) : base(Elements.water, Elements.earth)
    {
        prefab = Resources.Load("MudThrower") as GameObject;
        this.SpawnPoint = Emmiter;
    }

    public override void Execute()
    {
        GameObject projectile = Instantiate(prefab, SpawnPoint.transform.position, Quaternion.identity, SpawnPoint);
    }
}
