﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _player;
    private PlayerManager _playerManager;

    private bool isBossFight = false;

    private Vector3 currCheckpoint;

    public Vector3 CurrCheckpoint { get => currCheckpoint; set => currCheckpoint = value; }

    void Start()
    {
        _player = GameObject.Find("Maguito");
        _playerManager = _player.GetComponent<PlayerManager>();
        if (SceneManager.GetActiveScene().name == "BossFight_1")
        {
            isBossFight = true;
        }
        currCheckpoint = _player.transform.position;
    }

    void FixedUpdate()
    {
        if (_playerManager.CurrentHealth <= 0 && isBossFight == false)
        {
            _player.transform.position = new Vector3(currCheckpoint.x, currCheckpoint.y, 0);
            _playerManager.CurrentHealth = _playerManager.MaxHealth;
            _playerManager.HealthBar.SetHealth(_playerManager.CurrentHealth);
        }
        else if (_playerManager.CurrentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
