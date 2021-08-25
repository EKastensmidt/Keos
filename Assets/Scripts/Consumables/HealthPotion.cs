using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private GameObject _player;
    private PlayerManager _playerManager;
    [SerializeField] private int healAmmount = 50;
    void Start()
    {
        _player = GameObject.Find("Maguito");
        _playerManager = _player.GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (_playerManager.CurrentHealth < _playerManager.MaxHealth)
            {
                _playerManager.Heal(healAmmount);
                SoundManagerScript.PlaySound("Consumable");
                Destroy(gameObject);

            }   
        }
    }
}
