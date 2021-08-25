using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : Enemy
{
    private GameObject target;
    [SerializeField] private float xMove = 3f, detectDistance = 4f;
    private bool isInRange = false;
    private float randcd;
    private int posMultiplier = 1;

    void Start()
    {
        target = GameObject.Find("Maguito");
        randcd = Random.Range(1.5f, 2.5f);
    }

    void Update()
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
            float movement = -transform.right.x * Speed * Time.deltaTime;
            transform.position += new Vector3(movement, 0, 0);
        }
    }
}
