using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBall : Powers
{
    private GameObject prefab;
    private Transform SpawnPoint;
    private float spawnRate = 0.3f;
    private float speed = 500;
    public RockBall(Transform Emmiter) : base(Elements.earth, Elements.wind,"Rock Ball")
    {
        cooldownTime = spawnRate;
        prefab = Resources.Load("RockBall") as GameObject;
        this.SpawnPoint = Emmiter;
    }
    public override void Execute()
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
    }
}
