using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardSpike : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerManager _playerManager = collision.gameObject.GetComponent<PlayerManager>();
        if (_playerManager != null && !_playerManager.IsBubble)
        {
            _playerManager.TakeDamage(damage);
        }   
    }
}
