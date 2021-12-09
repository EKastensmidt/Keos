using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePower : MonoBehaviour
{
    private GameObject _player;
    private PlayerController _playerController;
    private PlayerManager _playerManager;

    [SerializeField] private static float health;

    public static float Health { get => health; set => health = value; }

    private void Start()
    {
        _player = GameObject.Find("Maguito");
        _playerController = _player.GetComponent<PlayerController>();
        _playerManager = _player.GetComponent<PlayerManager>();
    }
    void Update()
    {
        _playerManager.IsBubble = true;
        gameObject.transform.position = _player.transform.position;
        if (!_playerController.IsPlaying)
        {
            _playerManager.IsBubble = false;
            Destroy(gameObject);
        }
    }
}
