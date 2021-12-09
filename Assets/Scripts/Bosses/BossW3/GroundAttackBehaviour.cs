using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAttackBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 9)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
