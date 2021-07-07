using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCamera : MonoBehaviour
{
    public static Camera Camera;
    private float _horizontalSpeed = 5f;
    private readonly float _verticalSpeed = 5f;
    private float _sensitivity = 10f;
    private float _verticalRotationOffset = 0f;
    private float _horizontalRotationOffset = 0f;
    private readonly float _maxVerticalRotationAngle = 89;
    private float _defaultFOV = 60;
    private float _increasedFOV = 65;
    private float _fovChangingMult = 4f;
    private CameraInput Input => CameraInput.Input;

    private void Awake()
    {
        Camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        MoveHorizontal(Input.horizontalMovement);
        MoveVertical(Input.verticalMovement);
    }
    private void Update()
    {
        Rotate(Input.rotationDirection);
    }

    private void OnEnable()
    {
        Input.OnButtonPress += IncreaseSpeed;
        Input.OnButtonRemove += ReduceSpeed;
    }

    private void OnDisable()
    {
        Input.OnButtonPress -= IncreaseSpeed;
        Input.OnButtonRemove -= ReduceSpeed;
    }

    private void MoveHorizontal(Vector2 direction)
    {
        transform.position += transform.forward * direction.y * _horizontalSpeed * Time.deltaTime;
        transform.position += transform.right * direction.x * _horizontalSpeed * Time.deltaTime;
    }

    private void MoveVertical(float direction)
    {
        transform.position += transform.up * direction * _verticalSpeed * Time.deltaTime;
    }

    private void Rotate(Vector2 direction)
    {
        _horizontalRotationOffset += direction.x * _sensitivity * Time.deltaTime;
        _verticalRotationOffset += -direction.y * _sensitivity * Time.deltaTime;
        _verticalRotationOffset = Mathf.Clamp(_verticalRotationOffset, -_maxVerticalRotationAngle, _maxVerticalRotationAngle);
        transform.rotation = Quaternion.Euler(_verticalRotationOffset, _horizontalRotationOffset, 0);
    }

    private void IncreaseSpeed()
    {
        _horizontalSpeed *= 2;
        StopAllCoroutines();
        StartCoroutine(IncreaseFOV());
    }

    private void ReduceSpeed()
    {
        _horizontalSpeed /= 2;
        StopAllCoroutines();
        StartCoroutine(ReduceFOV());
    }

    private IEnumerator IncreaseFOV()
    {
        while (Camera.fieldOfView < _increasedFOV)
        {
            Camera.fieldOfView = Mathf.MoveTowards(Camera.fieldOfView, _increasedFOV, _fovChangingMult * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator ReduceFOV()
    {
        while (Camera.fieldOfView > _defaultFOV)
        {
            Camera.fieldOfView = Mathf.MoveTowards(Camera.fieldOfView, _defaultFOV, _fovChangingMult * Time.deltaTime);
            yield return null;
        }
    }
}
