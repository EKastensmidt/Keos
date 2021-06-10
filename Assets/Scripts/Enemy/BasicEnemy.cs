using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    [SerializeField] private GameObject wallDetect;
    [SerializeField] private WallDetect wallDetector;
    private float movement;
    private Vector3 localScale;
    private void Start()
    {
        wallDetector = wallDetect.GetComponent<WallDetect>();
        localScale = transform.localScale;
    }
    public override void FixedUpdate()
    {
        movement = -transform.right.x * Speed * Time.deltaTime;
        transform.position += new Vector3(movement,0,0);
        if (wallDetector.IsWall)
        {
            localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
            transform.localScale = localScale;
            Speed = Speed * -1;
            wallDetector.IsWall = false;
        }
    }
}
