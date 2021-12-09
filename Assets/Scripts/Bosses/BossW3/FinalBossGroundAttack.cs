using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossGroundAttack : MonoBehaviour
{
    [SerializeField] private GameObject prefab, _player;
    [SerializeField] private float attackSpeed, shootAngle;
    private float auxAttackSpeed;
    private void Start()
    {
        auxAttackSpeed = attackSpeed;
    }
    private void Update()
    {
        attackSpeed -= Time.deltaTime;

        if (attackSpeed < 0)
        {
            GameObject ball = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            ball.gameObject.GetComponent<Rigidbody2D>().velocity = BallisticVel(_player.transform, shootAngle);
            attackSpeed = auxAttackSpeed;
        }
    }

    private Vector3 BallisticVel(Transform target, float angle)
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
