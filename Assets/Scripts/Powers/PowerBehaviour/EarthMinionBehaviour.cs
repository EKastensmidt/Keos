using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMinionBehaviour : MonoBehaviour
{
    public float projectileSpawnOffset;
    private void Start()
    {
    }

    private void Update()
    {
        GameManager.EarthMinionPosition = transform.position;
    }
}
