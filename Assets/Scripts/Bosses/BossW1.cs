using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossW1 : Enemy
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
    private SpriteRenderer spriteRenderer;
    private float jumpTimer = 5f;
    private float spawnTimer = 2.6f;
    private Rigidbody2D rb;
    private int  bossMaxHealth;
    private bool secondStage = false;
    private bool isFacingRight = false;
    private float spawnOffset = -1;

    void Start()
    {
        prevTransform = platform1.transform;
        nextTransform = platform2.transform;
        transform.position = prevTransform.transform.position;
        bossMaxHealth = CurrHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (BossFightEnter.IsStarted)
        {
            jumpTimer -= Time.deltaTime;
            spawnTimer -= Time.deltaTime;
            Vector3 characterScale = transform.localScale;

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
                    if (isFacingRight)
                    {
                        characterScale.x = 1;
                        isFacingRight = false;
                    }
                    else
                    {
                        characterScale.x = -1;
                        isFacingRight = true;
                    }
                    spawnOffset *= -1;
                    transform.localScale = characterScale;
                    jumpTimer = 5f;
                }
            }
            if (spawnTimer <= 0)
            {
                Instantiate(basicEnemyPrefab, new Vector3(transform.position.x + spawnOffset,transform.position.y), Quaternion.identity);
                spawnTimer = 2.6f;
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        CurrHealth -= damage;
        DamagePoints(damage);
        if (CurrHealth != Previoushealth)
        {
            Previoushealth = CurrHealth;
            StartCoroutine(HitEffect());
        }

        if (CurrHealth <= 0)
        {
            Destroy(gameObject);
            
            SceneManager.LoadScene("EndOfDemo");
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
