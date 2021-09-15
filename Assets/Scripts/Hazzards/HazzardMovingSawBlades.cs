using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardMovingSawBlades : MonoBehaviour
{
    [SerializeField] private float speed, slowDist, fastDist;
    private float movement;
    private GameObject _player;
    private float defaultSpeed;
    void Start()
    {
        _player = GameObject.Find("Maguito");
        defaultSpeed = speed;
    }
    void Update()
    {
        var vectorToTarget = _player.transform.position - transform.position;
        vectorToTarget.y = 0;
        var distanceToTarget = vectorToTarget.magnitude;

        if (distanceToTarget <= slowDist)
        {
            speed = defaultSpeed + 1;
        }
        else if (distanceToTarget <=fastDist && distanceToTarget >= slowDist)
        {
            speed = defaultSpeed;
        }
        else
        {
            speed = defaultSpeed - 4;
        }

        movement = -transform.right.x * speed * Time.deltaTime;
        transform.position += new Vector3(movement, 0, 0);
    }
}
