using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMinionBehaviour : MonoBehaviour
{
    private void Update()
    {
        GameManager.EarthMinionPosition = transform.position;
    }
}
