using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFootInputActions;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _onFootInputActions = _playerInput.OnFoot;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _onFootInputActions.Enable();
        _playerInput.OnFoot.Jump.performed += ctx => _playerMovement.Jump();
    }

    private void OnDisable()
    {
        _onFootInputActions.Disable();
        _playerInput.OnFoot.Jump.performed -= ctx => _playerMovement.Jump();
    }

    private void FixedUpdate()
    {
        _playerMovement.ProccesMove(_onFootInputActions.Movement.ReadValue<Vector2>());
    }
}
