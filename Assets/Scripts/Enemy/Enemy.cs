using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currHealth;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private Material hitMaterial;
    private SpriteRenderer myRenderer;
    private float hitTimer = 0.1f;
    private int previoushealth;

    public int CurrHealth { get => currHealth; set => currHealth = value; }
    public int Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public Material Material { get => hitMaterial;  }
    public int Previoushealth { get => previoushealth; set => previoushealth = value; }

    void Awake()
    {
        currHealth = maxHealth;
        previoushealth = currHealth;
        myRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void Update()
    {
        
    }

    public IEnumerator HitEffect()
    {
        Material auxMaterial = myRenderer.material;
        myRenderer.material = hitMaterial;
        yield return new WaitForSeconds(hitTimer);
        myRenderer.material = auxMaterial;
    }
}
