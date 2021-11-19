using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float characterSpeed = 1;
    [SerializeField] private float jumpForce = 1;
    [SerializeField] private float momentum = 1;

    private float jumpLilTimer = 0f;

    private bool isPlaying = false;
    private bool isFacingRight = false;
    private bool isAbleMove = true;

    private Rigidbody2D _rigidbody;
    public Animator animator;
    private float movement;
    private bool jumped = false;
    private bool groundCheckDelay = false;
    public float CharacterSpeed { get => characterSpeed; set => characterSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public bool IsPlaying { get => isPlaying; }
    public Rigidbody2D Rigidbody { get => _rigidbody; set => _rigidbody = value; }
    public float Movement { get => movement; set => movement = value; }
    public bool IsFacingRight { get => isFacingRight; set => isFacingRight = value; }
    public Vector2 Delta { get => delta;}
    public bool IsAbleMove { get => isAbleMove; set => isAbleMove = value; }
    public GroundCheck GroundCheck { get => _groundCheck; set => _groundCheck = value; }
    public bool Jumped { get => jumped; set => jumped = value; }

    private PowerManager _powerManager;
    private GroundCheck _groundCheck;
    private Collider2D _collider;
    private Vector2 delta;

    [SerializeField] private ParticleSystem footSteps;
    private ParticleSystem.EmissionModule footStepsEmission;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _powerManager = GetComponent<PowerManager>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
        _collider = GetComponent<Collider2D>();
        footStepsEmission = footSteps.emission;
    }

    private void Update()
    {
        if (!isAbleMove)
            return;
        
        //MOVE
        movement = Input.GetAxis("Horizontal");
        if (!Physics2D.Raycast(transform.position, Vector2.right * movement, characterSpeed * Time.deltaTime + _collider.bounds.extents.x, LayerMask.GetMask("Ground", "Enemy")))
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * characterSpeed;
            animator.SetFloat("Speed", Mathf.Abs(movement));
        }

        //FOOT STEPS PARTICLES
        if (movement != 0 && _groundCheck.OnGround)
        {
            footStepsEmission.rateOverTime = 25f;
        }
        else
        {
            footStepsEmission.rateOverTime = 0;
        }

        //JUMP

        if (Input.GetButtonDown("Jump") && jumpLilTimer < 0f)
        {
            Jump();
        }

        if (GroundCheck.OnGround && groundCheckDelay)
            jumped = false;

        jumpLilTimer -= Time.deltaTime;
        
        //FLIP
        delta = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 characterScale = transform.localScale;

        if (delta.x > transform.position.x)
        {
            characterScale.x = 1;
            IsFacingRight = true;
        }
        if (delta.x < transform.position.x)
        {
            characterScale.x = -1;
            isFacingRight = false;
        }
        transform.localScale = characterScale;


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
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            _powerManager.GetElement(Elements.fire);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            _powerManager.GetElement(Elements.wind);
        }

        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.Alpha3)) && GameManager.IsWaterUnlocked)
        {
            _powerManager.GetElement(Elements.water);
        }

        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Alpha4)) && GameManager.IsEarthUnlocked)
        {
            _powerManager.GetElement(Elements.earth);
        }
    }

    IEnumerator jumpedDelay()
    {
        yield return new WaitForSeconds(0.3f);
        groundCheckDelay = true;
    }

    public void Jump()
    {
        if (_groundCheck.OnGround)
        {
            groundCheckDelay = false;
            jumpLilTimer = 0.3f;
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jumped = true;
            StartCoroutine(jumpedDelay());
            SoundManagerScript.PlaySound("Jump");
        }
    }
}
