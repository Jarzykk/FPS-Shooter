using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _sprintSpeed = 5f;
    [SerializeField] private float _jumpHeight = 1f;

    private float _gravity = -9.8f;
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private bool _isGrounded;
    private bool _isSprinting = false;
    private float _yVelocity = 2f;
    private float _currentSpeed;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _currentSpeed = _moveSpeed;
    }

    private void Update()
    {
        _isGrounded = _controller.isGrounded;
    }


    public void ProccesMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * _currentSpeed * Time.deltaTime);

        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y -= _yVelocity;

        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(_isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -_yVelocity * _gravity);
        }
    }

    public void ChangeSprintStance()
    {
        _isSprinting = !_isSprinting;

        if (_isSprinting == false)
            _currentSpeed = _moveSpeed;
        else if (_isSprinting)
            _currentSpeed = _sprintSpeed;
    }
}
