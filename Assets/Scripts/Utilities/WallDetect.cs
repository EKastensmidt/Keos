using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetect : MonoBehaviour
{
    private bool isWall = false;

    public bool IsWall { get => isWall; set => isWall = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0)
        {
            isWall = true;
        }
    }
}
