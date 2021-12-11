using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Powers
{
    private GameObject prefab;
    private GameObject _player;
    private PlayerController _playerController;
    public Bubble() : base(Elements.water, Elements.water,"Bubble")
    {
        prefab = Resources.Load("Bubble") as GameObject;
        _player = GameObject.Find("Maguito");
        _playerController = _player.GetComponent<PlayerController>();
    }

    public override void Execute()
    {
        if (BubblePower.Health > 0)
        {
            _playerController.Jump();
            GameObject bubble = Instantiate(prefab, _player.transform.position, Quaternion.identity, _player.transform);
            SoundManagerScript.PlaySound("Bubble");
        }
    }
}
