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
            
            collision.transform.position = new Vector3(GameManager.CurrCheckpoint.x, GameManager.CurrCheckpoint.y, 0);
            _playerManager.CurrentHealth = _playerManager.MaxHealth;
            _playerManager.HealthBar.SetHealth(_playerManager.CurrentHealth);
        }   
    }
}
