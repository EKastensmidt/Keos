using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField] private GameObject wallDetect;
    [SerializeField] private GameObject wallDetect2;
    private WallDetect wallDetector;
    private float movement;
    private void Start()
    {
        wallDetector = wallDetect.GetComponent<WallDetect>();
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        movement = -transform.right.x * Speed * Time.deltaTime;
        transform.position += new Vector3(movement,0,0);
        if (wallDetector.IsWall)
        {
            if (MyRenderer.flipX)
            {
                MyRenderer.flipX = false;
                wallDetector = wallDetect.GetComponent<WallDetect>();
            }
            else
            {
                MyRenderer.flipX = true;
                wallDetector = wallDetect2.GetComponent<WallDetect>();
            }
            Speed = Speed * -1;
            wallDetector.IsWall = false;
        }
    }
}
