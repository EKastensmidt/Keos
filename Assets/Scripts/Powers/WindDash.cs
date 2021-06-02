using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDash : Powers
{
    private PlayerController _playerController;
    private int dashDirection;
    private float dashForce = 5;
    public WindDash() : base(Elements.wind, Elements.wind)
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
    }

    public override void Execute()
    {
        dashDirection = (int)_playerController.Movement;
        _playerController.Rigidbody.velocity = _playerController.transform.right * dashDirection * dashForce;
    }
}
