using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
    private float spawnCd;
    private float spawnRate = 0.4f;
    private float speed = 500;
    public SnowBall(Transform Emmiter) : base(Elements.water, Elements.wind, "SnowBall")
    {
        prefab = Resources.Load("SnowBall") as GameObject;
        this.SpawnPoint = Emmiter;
    }

    public override void Execute()
    {
        if (spawnCd <= Time.time)
        {
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SpawnPoint.transform.position).normalized;

            if (GameManager.isEarthMinionActive)
            {
                GameObject earthMinionProjectile = Instantiate(prefab, GameManager.EarthMinionPosition, Quaternion.identity);
                Rigidbody2D earthMinionProjectileRB = earthMinionProjectile.GetComponent<Rigidbody2D>();
                earthMinionProjectileRB.AddForce(direction * speed);
            }

            GameObject projectile = Instantiate(prefab, SpawnPoint.position, Quaternion.identity);

            Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
            projectileRB.AddForce(direction * speed);

            SoundManagerScript.PlaySound("FireBall");
            spawnCd = Time.time + spawnRate;
        }
    }
}
