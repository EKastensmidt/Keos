using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedProjectileEnemy : Enemy
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float maxShootDistance = 4;
    [SerializeField] private float minShootDistance = 1;

    private GameObject _player;
    private float shootCd;
    [SerializeField] private float shootRate = 0.25f;
    [SerializeField] private float shootAngle = 30;
    [SerializeField] private float emmiterOffset = 1;

    void Start()
    {
        _player = GameObject.Find("Maguito");
    }
    void Update()
    {
        float dist = Mathf.Abs(_player.transform.position.x - transform.position.x);
        if (shootCd <= Time.time && (dist <= maxShootDistance && dist >= minShootDistance))
        {
            GameObject ball = Instantiate(prefab, new Vector3(transform.position.x,transform.position.y + emmiterOffset,transform.position.z), Quaternion.identity);
            ball.gameObject.GetComponent<Rigidbody2D>().velocity = BallisticVel(_player.transform, shootAngle);
            shootCd = Time.time + shootRate;
        }
    }
    public Vector3 BallisticVel(Transform target, float angle)
    {
        Vector3 dir = target.position - transform.position;
        float h = dir.y;  
        dir.y = 0;  
        float dist = dir.magnitude;  
        float a = angle * Mathf.Deg2Rad;  
        dir.y = dist * Mathf.Tan(a);  
        dist += h / Mathf.Tan(a);  
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized;
    }

}
