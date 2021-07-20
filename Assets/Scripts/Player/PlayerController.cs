﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float characterSpeed = 1;
    [SerializeField] private float jumpForce = 1;
    [SerializeField] private float momentum = 1;
    
    private bool isPlaying = false;
    private bool isFacingRight = false;

    private Rigidbody2D _rigidbody;
    public Animator animator;
    private float movement;
    public float CharacterSpeed { get => characterSpeed; set => characterSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public bool IsPlaying { get => isPlaying; }
    public Rigidbody2D Rigidbody { get => _rigidbody; set => _rigidbody = value; }
    public float Movement { get => movement; set => movement = value; }
    public bool IsFacingRight { get => isFacingRight; set => isFacingRight = value; }

    private PowerManager _powerManager;
    private GroundCheck _groundCheck;
    private Collider2D _collider;

    //[SerializeField] private float coyoteTimeFrames = 20;
    //private float coyoteTimeTimer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _powerManager = GetComponent<PowerManager>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        //ResetJumpCount();

        //MOVE

        //Vector2 velocity = _rigidbody.velocity;
        //velocity.x = Mathf.Lerp(velocity.x, movement * characterSpeed, momentum);
        //_rigidbody.velocity = velocity;
        movement = Input.GetAxis("Horizontal");
        if (Physics2D.Raycast(transform.position, Vector2.right * movement, characterSpeed * Time.deltaTime + _collider.bounds.extents.x, LayerMask.GetMask("Ground","Default")))
        {

        }
        else
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * characterSpeed;
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }

        //FLIP
        Vector2 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector3 characterScale = transform.localScale;

        if (delta.x > movement)
        {
            characterScale.x = 1;
            IsFacingRight = true;
        }
        if (delta.x < movement)
        {
            characterScale.x = -1;
            isFacingRight = false;
        }
        transform.localScale = characterScale;

        //JUMP
        if (Input.GetButtonDown("Jump") && _groundCheck.OnGround)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            SoundManagerScript.PlaySound("Jump");
            //if (_groundCheck.OnGround || coyoteTimeTimer < coyoteTimeFrames*/)
            //{
            //}
        }

        // ATTACK
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isPlaying = true;
            animator.SetBool("Attack", isPlaying);
            _powerManager.CombineElements();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isPlaying = false;
            animator.SetBool("Attack", isPlaying);
        }

        //ELEMENTS
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _powerManager.GetElement(Elements.fire);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _powerManager.GetElement(Elements.wind);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _powerManager.GetElement(Elements.water);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _powerManager.GetElement(Elements.earth);
        }
    }

    //private void ResetJumpCount()
    //{
    //    if (_groundCheck.OnGround)
    //    {
    //        coyoteTimeTimer = 0;
    //    }
    //    coyoteTimeTimer++;
    //}
}
