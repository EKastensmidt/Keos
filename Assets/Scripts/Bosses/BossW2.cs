using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossW2 : Enemy
{
    private bool isDead = false;
    private Animator animator;
    private CameraFollow cam;

    void Start()
    {
        animator = GetComponent<Animator>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraFollow>();

    }

    void Update()
    {
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
}
