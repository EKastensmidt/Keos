using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { fire}
public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private DamageType damageType;
    
    public int Damage { get => damage; set => damage = value; }
    public DamageType DamageType { get => damageType; set => damageType = value; }
}
