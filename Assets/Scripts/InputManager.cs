using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerLook))]
public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.OnFootActions _onFootInputActions;

    private PlayerMovement _playerMovement;
    private PlayerLook _playerLook;

    public event UnityAction ShootButtonPressed;
    public event UnityAction EquipNextWeaponPressed;
    public event UnityAction EquipPreviousWeaponPressed;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _onFootInputActions = _playerInput.OnFoot;

        _playerMovement = GetComponent<PlayerMovement>();
        _playerLook = GetComponent<PlayerLook>();
    }

    private void OnEnable()
    {
        _onFootInputActions.Enable();
        _playerInput.OnFoot.Jump.performed += ctx => _playerMovement.Jump();
        _playerInput.OnFoot.Sprint.performed += ctx => _playerMovement.ChangeSprintStance();
        _playerInput.OnFoot.Sprint.canceled += ctx => _playerMovement.ChangeSprintStance();
        _playerInput.OnFoot.Shoot.performed += ctx => OnShootButtonPressed();

        _playerInput.OnFoot.EquipNextWeapon.performed += ctx => OnEquipNextWeaponPressed();
        _playerInput.OnFoot.EquipPreviousWeapon.performed += ctx => OnEquipPreviousWeaponPressed();
    }

    private void OnDisable()
    {
        _onFootInputActions.Disable();
        _playerInput.OnFoot.Jump.performed -= ctx => _playerMovement.Jump();
        _playerInput.OnFoot.Sprint.performed -= ctx => _playerMovement.ChangeSprintStance();
        _playerInput.OnFoot.Sprint.canceled -= ctx => _playerMovement.ChangeSprintStance();
        _playerInput.OnFoot.Shoot.performed -= ctx => OnShootButtonPressed();
        _playerInput.OnFoot.EquipNextWeapon.performed -= ctx => OnEquipNextWeaponPressed();
        _playerInput.OnFoot.EquipPreviousWeapon.performed -= ctx => OnEquipPreviousWeaponPressed();

    }
    
    public void DisableControlls()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        _playerMovement.ProccesMove(_onFootInputActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _playerLook.ProcessLook(_onFootInputActions.Look.ReadValue<Vector2>());
    }

    private void OnShootButtonPressed()
    {
        ShootButtonPressed?.Invoke();
    }

    private void OnEquipNextWeaponPressed()
    {
        EquipNextWeaponPressed?.Invoke();
    }

    private void OnEquipPreviousWeaponPressed()
    {
        EquipPreviousWeaponPressed?.Invoke();
    }    
}
