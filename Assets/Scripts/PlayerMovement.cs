using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _controller;
    private Vector3 _playerVelocity;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    public void ProccesMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
    }
}
