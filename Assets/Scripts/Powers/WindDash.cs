using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDash : Powers
{
    private PlayerController _playerController;
    private GameObject _particleObject;
    private GameObject _particleSpawnPoint;

    private Vector3 dashParticleOffset; 
    private float dashDirection;
    private float dashForce = 5;
    private float dashRate = 1;
    private float dashCd = 0;
    public WindDash() : base(Elements.wind, Elements.wind)
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
        _particleSpawnPoint = GameObject.Find("GroundCheck");
        _particleObject = Resources.Load("WindDash") as GameObject;
    }

    public override void Execute()
    {
        if (dashCd <= Time.time)
        {
            dashCd = Time.time + dashRate;
            dashParticleOffset = _playerController.IsFacingRight ? dashParticleOffset = new Vector3(0,180,0) : dashParticleOffset = Vector3.zero;
            GameObject dash = Instantiate(_particleObject, _particleSpawnPoint.transform.position, Quaternion.identity, _particleSpawnPoint.transform);
            dash.transform.Rotate(dashParticleOffset);
            dashDirection = _playerController.Movement;
            //Vector3 velocity = _playerController.Rigidbody.velocity;
            if (dashDirection != 0)
            {
                _playerController.Rigidbody.velocity = _playerController.transform.right * dashDirection * dashForce; //+ velocity;
            }
            else
            {
                if (_playerController.IsFacingRight)
                    _playerController.Rigidbody.velocity = _playerController.transform.right * dashForce;
                else
                    _playerController.Rigidbody.velocity = -_playerController.transform.right * dashForce;
            }
            SoundManagerScript.PlaySound("WindDash");
        }
    }
}
