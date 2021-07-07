using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugActions : MonoBehaviour
{
    public static DebugActions Input;
    private PlayerInput _input;
    public delegate void DebugButtonPressed();
    public event DebugButtonPressed OnDebugButton1Press;
    public event DebugButtonPressed OnDebugButton2Press;

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

        _input.Camera.DebugButton.performed += context => OnDebugButton1Press();
        _input.Camera.DebugButton2.performed += context => OnDebugButton2Press();

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
