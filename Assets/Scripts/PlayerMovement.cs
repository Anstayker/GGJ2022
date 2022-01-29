using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Movement")]
    [SerializeField] private float acceleration = 10.0f;
    [SerializeField] private float maxSpeed = 10.0f;

    private InputManager _inputManager;
    private Rigidbody2D _rigidbody2D;
    private bool _isFacingRight = true;
    private SpriteController _playerSprite;
    private Animator _animatorColor;
    private Animator _animatorMono;
    private static readonly int Velocity = Animator.StringToHash("velocity");

    public bool canMove = true;
    
    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputManager = GetComponent<InputManager>();
        _playerSprite = GetComponentInChildren<SpriteController>();
        _animatorColor = _playerSprite.colorSprite.GetComponent<Animator>();
        _animatorMono = _playerSprite.monoSprite.GetComponent<Animator>();
    }

    private void FixedUpdate() {
        if (canMove) {
            ProcessMovement(_inputManager.InputMovement);
        } else {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    private void ProcessMovement(Vector2 inputMovement) {
        Vector2 movement = new Vector2(
            inputMovement.x * acceleration,
            inputMovement.y * acceleration);
        _rigidbody2D.velocity = movement;

        if ((inputMovement.x > 0 && !_isFacingRight) || (inputMovement.x < 0 && _isFacingRight)) {
            Flip();
        }

        _animatorColor.SetFloat(Velocity, Mathf.Abs(_rigidbody2D.velocity.magnitude));
        _animatorMono.SetFloat(Velocity, Mathf.Abs(_rigidbody2D.velocity.magnitude));
        
        if (_rigidbody2D.velocity.magnitude > maxSpeed) {
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * maxSpeed;
        }
    }

    private void Flip() {
        _isFacingRight = !_isFacingRight;
        _playerSprite.transform.rotation = Quaternion.Euler(0, _isFacingRight ? 0 : 180, 0);
    }
}
