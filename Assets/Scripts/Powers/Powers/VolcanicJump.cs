using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicJump : Powers
{
    private PlayerController _playerController;
    private GameObject _particleObject;
    private GameObject _particleSpawnPoint;

    private Vector3 jumpParticleOffset;
    private float jumpForce = 10;
    private float jumpRate = 2;
    private float jumpCd = 0;
    public VolcanicJump() : base(Elements.fire, Elements.earth,"VolcanicJump")
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
        _particleSpawnPoint = GameObject.Find("GroundCheck");
        _particleObject = Resources.Load("VolcanicJump") as GameObject;
    }

    public override void Execute()
    {
        jumpParticleOffset = _playerController.IsFacingRight ? jumpParticleOffset = new Vector3(0, 180, 0) : jumpParticleOffset = Vector3.zero;

        if (_playerController.GroundCheck.OnGround)
        {
            GameObject jump = Instantiate(_particleObject, _particleSpawnPoint.transform.position, Quaternion.identity, _particleSpawnPoint.transform);
            jump.transform.Rotate(jumpParticleOffset);
            SoundManagerScript.PlaySound("WindDash");

            if (_playerController.Movement != 0)
                _playerController.Rigidbody.velocity = _playerController.transform.up * jumpForce * Mathf.Abs( _playerController.Movement);
            else
                _playerController.Rigidbody.velocity = _playerController.transform.up * jumpForce;
        }
    }
}
