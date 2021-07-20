using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightEnter : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Enemy Boss;
    private Collider2D collider;
    private static bool isStarted = false;

    public static bool IsStarted { get => isStarted; set => isStarted = value; }

    void Start()
    {
        collider = GetComponent<Collider2D>();
        healthBar.SetMaxHealth(Boss.MaxHealth);
    }

    private void Update()
    {
        if (isStarted)
        {
            healthBar.SetHealth(Boss.CurrHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y - 2f, gate.transform.position.z);
            collider.enabled = false;
            isStarted = true;
            healthBar.gameObject.SetActive(isStarted);
        }
    }
}
