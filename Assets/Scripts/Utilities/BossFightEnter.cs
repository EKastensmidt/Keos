using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightEnter : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    private Collider2D collider;
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y - 2f, gate.transform.position.z);
            collider.enabled = false;
        }
    }
}
