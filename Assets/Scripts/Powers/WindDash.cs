using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDash : Powers
{
    private PlayerController _playerController;
    private float dashDirection;
    private float dashForce = 5;
    public WindDash() : base(Elements.wind, Elements.wind)
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
    }

    public override void Execute()
    {
        dashDirection = _playerController.Movement;
        if (dashDirection != 0)
        {
            _playerController.Rigidbody.velocity = _playerController.transform.right * dashDirection * dashForce;
        }
        else
        {
            if (_playerController.IsFacingRight)
                _playerController.Rigidbody.velocity = _playerController.transform.right * dashForce;
            else
                _playerController.Rigidbody.velocity = -_playerController.transform.right * dashForce;
        }
    }
}
