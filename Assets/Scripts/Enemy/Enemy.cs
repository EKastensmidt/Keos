using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currHealth;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    private SpriteRenderer myRenderer;
    private float hitTimer = 0.1f;
    private int previoushealth;
    private Material auxMaterial;
    private Color myColor;
    [SerializeField] private GameObject damagePopup;
    [SerializeField] private float damagePopupOffset = 5f;

    public int CurrHealth { get => currHealth; set => currHealth = value; }
    public int Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }
    public int Previoushealth { get => previoushealth; set => previoushealth = value; }
    public SpriteRenderer MyRenderer { get => myRenderer; set => myRenderer = value; }

    void Awake()
    {
        currHealth = maxHealth;
        previoushealth = currHealth;
        myRenderer = GetComponent<SpriteRenderer>();
        myColor = myRenderer.color;
    }

    public virtual void FixedUpdate()
    {
        
    }

    public IEnumerator HitEffect()
    {
        myRenderer.color = Color.red;
        yield return new WaitForSeconds(hitTimer);
        myRenderer.color = myColor;
    }

    public virtual void TakeDamage(int damage)
    {
        currHealth -= damage;
        DamagePoints(damage);
        if (CurrHealth != Previoushealth)
        {
            Previoushealth = CurrHealth;
            StartCoroutine(HitEffect());
        }

        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DamagePoints(int damage)
    {
        GameObject damagePoints = Instantiate(damagePopup, transform.position, Quaternion.identity);
        damagePoints.GetComponent<TextMeshPro>().SetText(damage.ToString());
        SoundManagerScript.PlaySound("EnemyHit");
    }
}
