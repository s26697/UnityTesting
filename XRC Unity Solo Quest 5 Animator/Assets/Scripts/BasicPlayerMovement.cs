using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class BasicPlayerMovement : MonoBehaviour {
    private Rigidbody2D _rb;
    private float _xInput;
    [SerializeField] private float _speed = 5;

    private bool _performJump;
    private bool _isGrounded;
    [SerializeField] private float _jumpForce = 5;

    private SpriteRenderer _sr;

    private Animator _animator;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        _xInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _isGrounded) {
            _performJump = true;
        }
    }

    private void FixedUpdate() {
        _rb.velocity = new Vector2(_xInput * _speed, _rb.velocity.y);

        if (_performJump) {
            _performJump = false;
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
        Flip();
        _animator.SetFloat("XinputAbs",Math.Abs(_xInput));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        _isGrounded = true;
        _animator.SetBool("isGrounded", true);
    }

    private void OnCollisionExit2D(Collision2D other) {
        _isGrounded = false;
        _animator.SetBool("isGrounded", false);
    }

    private void Flip()
    {
        if (_rb.velocity.x > 0)
        {
            _sr.flipX = false;
        }else if (_rb.velocity.x < 0)
        {
            _sr.flipX = true;
        }
    }

    public void Die()
    {
        _animator.SetTrigger("Die");
    }
    
    
}