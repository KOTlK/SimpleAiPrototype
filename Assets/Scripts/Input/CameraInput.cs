using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
    public Vector2 horizontalMovement;
    public Vector2 rotationDirection;
    public float verticalMovement;
    public static CameraInput Input;
    public delegate void Sprint();
    public event Sprint OnButtonPress;
    public event Sprint OnButtonRemove;


    private PlayerInput _input;

    private void Awake()
    {
        _input = new PlayerInput();

        if (Input == null)
        {
            Input = this;
        } else
        {
            throw new System.NullReferenceException();
        }

        _input.Camera.Sprint.started += context => OnButtonPress();
        _input.Camera.Sprint.canceled += context => OnButtonRemove();
    }

    private void Update()
    {
        horizontalMovement = _input.Camera.Movement.ReadValue<Vector2>();
        rotationDirection = _input.Camera.Rotation.ReadValue<Vector2>();
        verticalMovement = _input.Camera.UpDownFly.ReadValue<float>();

    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}
