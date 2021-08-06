using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
    private float spawnCd;
    private float spawnRate = 0.4f;
    private float speed = 420;
    private Vector3 direction;
    public SnowBall(Transform Emmiter) : base(Elements.water, Elements.wind)
    {
        prefab = Resources.Load("SnowBall") as GameObject;
        this.SpawnPoint = Emmiter;
    }

    public override void Execute()
    {
        if (spawnCd <= Time.time)
        {
            GameObject projectile = Instantiate(prefab, SpawnPoint.position, Quaternion.identity);

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SpawnPoint.transform.position).normalized;
            projectileRB.AddForce(direction * speed);

            SoundManagerScript.PlaySound("FireBall");
            spawnCd = Time.time + spawnRate;
        }
    }
}
