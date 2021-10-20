using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossW2 : Enemy
{
    private float escapeSpeed = 8.5f;
    private bool isDead = false;
    private Animator animator;
    private CameraFollow cam;
    private CharacterDialogManager dialogueManager;
    private BossFight2Enter boss2Enter;
    [SerializeField] private Vector3 escapedPosition;

    private bool isFirstPhase = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        dialogueManager = GameObject.Find("NewDialogueManager").GetComponent<CharacterDialogManager>();
        boss2Enter = GameObject.Find("BossFight2Enter").GetComponent<BossFight2Enter>();

    }

    void Update()
    {
        if (dialogueManager.IsInDialogue)
        {
            isFirstPhase = true;
            return;
        }

        if (!isFirstPhase)
            return;
        
        if (boss2Enter.IsEntered)
        {
            boss2Enter.QueueObjects();
            transform.position += Vector3.right * Time.deltaTime * escapeSpeed;
            StartCoroutine(TPToNextPosition());
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
           
            animator.SetInteger("Health", CurrHealth);
            StartCoroutine(SpawnParticles(4f));
        }
    }
    private IEnumerator SpawnParticles(float time)
    {
        GameObject _playeraux = cam.Player;
        cam.Player = this.gameObject;
        Destroy(gameObject, time + 0.1f);
        yield return new WaitForSeconds(time);
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        cam.Player = _playeraux;
    }

    IEnumerator TPToNextPosition()
    {
        yield return new WaitForSeconds(2f);
        transform.position = escapedPosition;
        isFirstPhase = false;
    }
}
