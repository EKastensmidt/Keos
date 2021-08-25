using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : Enemy
{
    private GameObject target;
    private Animator animator;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float xMove = 3f, detectDistance = 4f, fireRate = 1f;
    private bool isInRange = false;
    private float randcd, fireCD = 0;
    private int posMultiplier = 1;
    private Rigidbody2D rb;

    void Start()
    {
        target = GameObject.Find("Maguito");
        animator = GetComponent<Animator>();
        randcd = Random.Range(1.5f, 2.5f);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        randcd -= Time.deltaTime;
        float distx = Mathf.Abs(target.transform.position.x - transform.position.x);
        float disty = Mathf.Abs(target.transform.position.y - transform.position.y);

        if (distx <= detectDistance && disty <= detectDistance)
            isInRange = true;

        if (isInRange)
        {
            if (randcd <= 0)
            {
                Speed = Speed * -1;
                randcd = Random.Range(1f, 2f);
            }
            
            float movement = -transform.right.x * Speed * Time.fixedDeltaTime;
            rb.MovePosition((Vector2)transform.position + new Vector2(movement, 0));
            //transform.position += new Vector3(movement, 0, 0);

            if(fireCD <= Time.time)
            {
                animator.SetBool("isAttack", true);
                GameObject enemyProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                fireCD = Time.time + fireRate;
            }
        }
    }
}
