using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
    public FlameThrower(Transform Emmiter): base(Elements.fire, Elements.fire, "FlameThrower")
    {
        prefab = Resources.Load("FlameThrower") as GameObject;
        this.SpawnPoint = Emmiter;
    }

    public override void Execute()
    {
        if (GameManager.isEarthMinionActive)
        {
            Instantiate(prefab, GameManager.EarthMinionPosition, Quaternion.identity);
        }
        Instantiate(prefab, SpawnPoint.transform.position, Quaternion.identity, SpawnPoint);         
    }
}
