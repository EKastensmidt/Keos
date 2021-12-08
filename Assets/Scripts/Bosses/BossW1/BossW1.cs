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
    [SerializeField] private GameObject secondPhaseSpawns, thirdPhaseSpawns;
    [SerializeField] private int maxEnemies = 5;

    private Transform prevTransform;
    private Transform nextTransform;
    private Transform auxTransform;
    private float jumpTimer = 5f;
    private float spawnTimer = 2.6f;
    private Rigidbody2D rb;
    private int bossMaxHealth;
    private bool secondStage = false;
    private bool thirdStage = false;
    private bool isFacingRight = false;
    private bool isEntered = false;
    private float spawnOffset = -1;
    private List<GameObject> enemies = new List<GameObject>();
    private bool spawnReady = true;
    private BossFightEnter bossEnter;
    private Animator animator;
    private bool isDead = false;
    private CameraFollow cam;
    private CharacterDialogManager dialogueManager;
    private bool isMusicOn = false;

    void Start()
    {
        prevTransform = platform1.transform;
        nextTransform = platform2.transform;
        bossMaxHealth = CurrHealth;
        cam = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        rb = GetComponent<Rigidbody2D>();
        bossEnter = GameObject.Find("BossFightEnter").GetComponent<BossFightEnter>();
        animator = GetComponent<Animator>();
        dialogueManager = GameObject.Find("NewDialogueManager").GetComponent<CharacterDialogManager>();
    }

    public override void Update()
    {
        if (isDead != false)
            return;
        if (!isEntered)
        {
            isEntered = true;
            transform.position = prevTransform.transform.position;
        }
        if (dialogueManager.IsInDialogue)
            return;
        base.Update();

        if (BossFightEnter.IsStarted)
        {
            if (!isMusicOn)
            {
                bossEnter.QueueMusic();
                isMusicOn = true;
            }
            jumpTimer -= Time.deltaTime;
            spawnTimer -= Time.deltaTime;
            Vector3 characterScale = transform.localScale;

            if (jumpTimer <= 0)
            {
                if (CurrHealth <= bossMaxHealth / 1.5f && !secondStage)
                {
                    animator.SetInteger("Health", CurrHealth);
                    JumpToPlatform(platformMain.transform);
                    secondStage = true;
                    secondPhaseSpawns.SetActive(true);
                    jumpTimer = 5f;
                }
                else if (CurrHealth <= bossMaxHealth / 3f && !thirdStage)
                {
                    animator.SetInteger("Health", CurrHealth);
                    JumpToPlatform(platformMain.transform);
                    thirdStage = true;
                    thirdPhaseSpawns.SetActive(true);
                    jumpTimer = 7.5f;
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

                    if (thirdStage)
                        jumpTimer = 2.5f;
                    else if (secondStage)
                        jumpTimer = 4.5f;
                    else
                        jumpTimer = 6f;
                }
            }

            if (spawnTimer <= 0 && spawnReady)
            {
                animator.SetBool("SpawnReady", true);
                GameObject enemy = Instantiate(basicEnemyPrefab, new Vector3(transform.position.x + spawnOffset, transform.position.y), Quaternion.identity);
                if (isFacingRight && enemy != null)
                {
                    enemy.gameObject.GetComponentInChildren<WallDetect>().IsWall = true;
                }
                enemies.Add(enemy);

                if (thirdStage)
                    spawnTimer = 1.3f;
                else if (secondStage)
                    spawnTimer = 2f;
                else
                    spawnTimer = 2.6f;

                if (enemies.Count > 5)
                {
                    spawnReady = false;
                }
            }
            else
            {
                animator.SetBool("SpawnReady", false);
            }

            if (!spawnReady)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i] == null)
                    {
                        enemies.RemoveAt(i);
                        spawnReady = true;
                    }
                }
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
            isDead = true;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].GetComponent<Enemy>().TakeDamage(100);
                }
            }
            bossEnter.DeQueueMusic();
            spawnReady = false;
            thirdPhaseSpawns.SetActive(false);
            secondPhaseSpawns.SetActive(false);
            animator.SetInteger("Health", CurrHealth);
            StartCoroutine(SpawnParticles(4f));
        }
    }

    public override void TakeStatusEffectDamage(int damage)
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
            isDead = true;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] != null)
                {
                    enemies[i].GetComponent<Enemy>().TakeDamage(100);
                }
            }
            spawnReady = false;
            thirdPhaseSpawns.SetActive(false);
            secondPhaseSpawns.SetActive(false);
            animator.SetInteger("Health", CurrHealth);
            StartCoroutine(SpawnParticles(4f));
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

    private IEnumerator SpawnParticles(float time)
    {
        GameObject _playeraux = cam.Player;
        cam.Player = this.gameObject;
        bossEnter.ReOpenGates(7f);
        Destroy(gameObject, time + 0.1f);
        yield return new WaitForSeconds(time);
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
    }
}
