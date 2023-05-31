using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _xSensetivity = 30f;
    [SerializeField] private float _ySensetivity = 30f;

    private Camera _camera;
    private float _xRotation = 0f;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        RotateByVerticalAxis(mouseY);
        RotateByHorizontal(mouseX);
    }

    private void RotateByVerticalAxis(float mouseYValue)
    {
        float xClampValue = 80;

        _xRotation -= (mouseYValue * Time.deltaTime) * _ySensetivity;
        _xRotation = Mathf.Clamp(_xRotation, -xClampValue, xClampValue);
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
    }

    private void RotateByHorizontal(float mouseXValue)
    {
        transform.Rotate(Vector3.up * (mouseXValue * Time.deltaTime) * _xSensetivity);
    }
}
