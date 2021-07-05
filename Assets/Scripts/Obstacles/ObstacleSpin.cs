using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpin : MonoBehaviour
{
    [SerializeField] private float obstacleSpin = 0.2f;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * obstacleSpin);
    }
}
