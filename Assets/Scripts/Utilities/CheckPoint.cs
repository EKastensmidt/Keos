using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameObject _manager;
    private GameManager _gameManager;
    private void Start()
    {
        _manager = GameObject.Find("GameManager");
        _gameManager = _manager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Maguito")
        {
            _gameManager.CurrCheckpoint = transform.position;
        }
    }
}
