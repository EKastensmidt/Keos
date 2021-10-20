using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBall : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
    private float spawnCd;
    private float spawnRate = 0.3f;
    private float speed = 500;
    public RockBall(Transform Emmiter) : base(Elements.earth, Elements.wind,"RockBall")
    {
        prefab = Resources.Load("RockBall") as GameObject;
        this.SpawnPoint = Emmiter;
    }
    public override void Execute()
    {
        if (spawnCd <= Time.time)
        {
            GameObject projectile = Instantiate(prefab, SpawnPoint.position, Quaternion.identity);

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SpawnPoint.transform.position).normalized;
            projectileRB.AddForce(direction * speed);

            SoundManagerScript.PlaySound("FireBall");
            spawnCd = Time.time + spawnRate;
        }
    }
}
