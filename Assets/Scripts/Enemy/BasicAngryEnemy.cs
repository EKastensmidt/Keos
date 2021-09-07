using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAngryEnemy : Enemy
{
    [SerializeField] private GameObject wallDetect;
    [SerializeField] private float maxDistance = 4, angrySpeed = 2;
    private WallDetect wallDetector;
    private float movement;
    private Vector3 localScale;
    private bool isAngry = false;
    private Animator animator;
    private Transform _player;
    private SpriteRenderer spriteRenderer;
    
    public WallDetect WallDetector { get => wallDetector; set => wallDetector = value; }

    private void Start()
    {
        wallDetector = wallDetect.GetComponent<WallDetect>();
        localScale = transform.localScale;
        animator = GetComponent<Animator>();
        _player = GameObject.Find("Maguito").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void FixedUpdate()
    {
        float dist = Vector2.Distance(_player.position, transform.position);
        
        if (dist <= maxDistance)
        {
            isAngry = true;
            animator.SetBool("IsAngry", isAngry);
        }
        else if (dist > maxDistance * 1.5f)
        {
            isAngry = false;
            animator.SetBool("IsAngry", isAngry);
        }

        if (isAngry)
        {
            transform.Translate((_player.position - transform.position).normalized * angrySpeed * Time.deltaTime);

            if (localScale.x != -1)
            {
                if (_player.position.x - transform.position.x > 0)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                }
            }
            else
            {
                if (_player.position.x - transform.position.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
            }
        }
        else
        {
            spriteRenderer.flipX = false;
            movement = -transform.right.x * Speed * Time.deltaTime;
            transform.position += new Vector3(movement, 0, 0);
            if (wallDetector.IsWall)
            {
                localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
                transform.localScale = localScale;
                Speed = Speed * -1;
                wallDetector.IsWall = false;
            }
        }
    }
}
