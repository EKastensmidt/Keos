using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Powers
{
    private GameObject prefab;
    private GameObject _player;
    public Bubble() : base(Elements.water, Elements.water,"Bubble")
    {
        prefab = Resources.Load("Bubble") as GameObject;
        _player = GameObject.Find("Maguito");
    }

    public override void Execute()
    {
        GameObject bubble = Instantiate(prefab, _player.transform.position, Quaternion.identity,_player.transform);
        SoundManagerScript.PlaySound("Bubble");
    }
}
