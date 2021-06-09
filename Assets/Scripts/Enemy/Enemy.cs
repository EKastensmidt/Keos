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
    private float hitTimer = 0.3f;
    private int previoushealth;
    private Material auxMaterial;


    public int CurrHealth { get => currHealth; set => currHealth = value; }
    public int Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public Material Material { get => hitMaterial;  }
    public int Previoushealth { get => previoushealth; set => previoushealth = value; }
    public SpriteRenderer MyRenderer { get => myRenderer; set => myRenderer = value; }

    void Awake()
    {
        currHealth = maxHealth;
        previoushealth = currHealth;
        myRenderer = GetComponent<SpriteRenderer>();
        auxMaterial = myRenderer.material;
    }

    public virtual void FixedUpdate()
    {
        if (CurrHealth != Previoushealth)
        {
            Previoushealth = CurrHealth;
            StartCoroutine(HitEffect());
        }

        if (CurrHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator HitEffect()
    {
        myRenderer.material = hitMaterial;
        yield return new WaitForSeconds(hitTimer);
        myRenderer.material = auxMaterial;
    }
}
