using System;
using UnityEngine;

namespace Player {
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

            _animator.SetFloat("XInputAbs", Math.Abs(_xInput));
        }

        private void Flip() {
            if (_xInput > 0) {
                _sr.flipX = false;
            }
            else if (_xInput < 0) {
                _sr.flipX = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D other) {
            _isGrounded = true;
            _animator.SetBool("IsGrounded", true);
        }

        private void OnCollisionExit2D(Collision2D other) {
            _isGrounded = false;
            _animator.SetBool("IsGrounded", false);
        }

        public void Die() {
            _animator.SetTrigger("Die");
        }
    }
}