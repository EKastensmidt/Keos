using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardMovingSawBlades : MonoBehaviour
{
    [SerializeField] private float speed;
    private float movement;
    void Update()
    {
        movement = -transform.right.x * speed * Time.deltaTime;
        transform.position += new Vector3(movement, 0, 0);
    }
}
