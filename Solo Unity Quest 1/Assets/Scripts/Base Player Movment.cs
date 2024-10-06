
using System;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class BasePlayerMovment : MonoBehaviour

{
    private Rigidbody2D _rb;

    private float _xInput;
    
    [SerializeField] private float _speed = 5;

    private bool _performjump;
    private bool _isGrounded;
    [SerializeField] private float _jumpforce = 5;
    
    // initialize rigidbody
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // input calls
    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _performjump = true;
        }
    }
    
    // rigidbody methods as in documentation
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_xInput * _speed, _rb.velocity.y );

        if (_performjump)
        {
            _performjump = false;
            _isGrounded = false;
            _rb.AddForce(new Vector2(0, _jumpforce), ForceMode2D.Impulse );
        }
    }

    //   collision
    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isGrounded = false;
    }
}
