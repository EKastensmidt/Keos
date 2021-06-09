using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
<<<<<<< HEAD
=======
    private float spawnCd;
    private float spawnRate = 0.5f;
<<<<<<< HEAD
>>>>>>> parent of d9aff8e (hit detection fix & enemies)
=======
>>>>>>> parent of d9aff8e (hit detection fix & enemies)
    public FireBall(Transform Emmiter) : base(Elements.fire, Elements.wind)
    {
        prefab = Resources.Load("FireBall") as GameObject;
        this.SpawnPoint = Emmiter;
    }

    public override void Execute()
    {
        GameObject projectile = Instantiate(prefab, SpawnPoint.position, Quaternion.identity);
    }
}
