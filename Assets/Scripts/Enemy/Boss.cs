using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;
    [SerializeField] private GameObject platformMain;

    [SerializeField] private float jumpAngle = 60;
    [SerializeField] private GameObject basicEnemyPrefab;
    [SerializeField] private GameObject secondPhaseSpawns;

    private Transform prevTransform;
    private Transform nextTransform;
    private Transform auxTransform;
    private float jumpTimer = 5f;
    private float spawnTimer = 2.4f;
    private Rigidbody2D rb;
    private int  bossMaxHealth;
    private bool secondStage = false;

    void Start()
    {
        prevTransform = platform1.transform;
        nextTransform = platform2.transform;
        transform.position = prevTransform.transform.position;
        bossMaxHealth = CurrHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (BossFightEnter.IsStarted)
        {
            jumpTimer -= Time.deltaTime;
            spawnTimer -= Time.deltaTime;

            
            if (jumpTimer <= 0)
            {
                if (CurrHealth <= bossMaxHealth/2 && !secondStage)
                {
                    JumpToPlatform(platformMain.transform);
                    secondStage = true;
                    secondPhaseSpawns.SetActive(true);
                    jumpTimer = 10f;
                }
                else
                {
                    JumpToPlatform(nextTransform);
                    auxTransform = prevTransform;
                    prevTransform = nextTransform;
                    nextTransform = auxTransform;
                    jumpTimer = 5f;
                }
            }
            if (spawnTimer <= 0)
            {
                Instantiate(basicEnemyPrefab, transform.position, Quaternion.identity);
                spawnTimer = 2.4f;
            }
        }
    }

    private void JumpToPlatform(Transform target)
    {
        rb.velocity = BallisticVel(target, jumpAngle);
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
