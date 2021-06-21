using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardSpike : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Maguito")
        {
            PlayerManager _player = collision.gameObject.GetComponent<PlayerManager>();
            if (_player != null)
            {
                _player.TakeDamage(damage);
            }
                
        }
    }
}
