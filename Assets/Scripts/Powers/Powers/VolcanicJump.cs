using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicJump : Powers
{
    private PlayerController _playerController;
    private GameObject _particleObject;
    private GameObject _particleSpawnPoint;

    private Vector3 jumpParticleOffset;
    private float jumpForce = 10f;
    private float jumpRate = 1f;
    private float jumpCd = 0f;
    public VolcanicJump() : base(Elements.fire, Elements.earth,"VolcanicJump")
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
        _particleSpawnPoint = GameObject.Find("GroundCheck");
        _particleObject = Resources.Load("VolcanicJump") as GameObject;
    }

    public override void Execute()
    {
        jumpParticleOffset = _playerController.IsFacingRight ? jumpParticleOffset = new Vector3(0, 180, 0) : jumpParticleOffset = Vector3.zero;

        if (((_playerController.GroundCheck.OnGround && !_playerController.Jumped) || _playerController.Jumped) && jumpCd <= Time.time)
        {
            SoundManagerScript.PlaySound("VolcanicJump");
            jumpCd = jumpRate + Time.time;
            _playerController.Jumped = false;
            GameObject jump = Instantiate(_particleObject, _particleSpawnPoint.transform.position, Quaternion.identity, _particleSpawnPoint.transform);
            jump.transform.Rotate(jumpParticleOffset);
            _playerController.Rigidbody.AddForce(_playerController.transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
