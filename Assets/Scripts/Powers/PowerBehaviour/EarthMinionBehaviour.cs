using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthMinionBehaviour : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
    }

    private void Update()
    {
        
    }
}
