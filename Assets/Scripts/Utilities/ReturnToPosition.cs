using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPosition : MonoBehaviour
{
    [SerializeField] private GameObject desiredPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Maguito")
        {
            collision.transform.position = desiredPosition.transform.position;
        }
    }
}
