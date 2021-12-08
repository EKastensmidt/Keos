using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossParticleAttack : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnParticleCollision(GameObject other)
    {
        PlayerManager _playerManager = other.GetComponent<PlayerManager>();
        if (_playerManager != null)
        {
            _playerManager.TakeDamage(damage);
        }
    }
}
