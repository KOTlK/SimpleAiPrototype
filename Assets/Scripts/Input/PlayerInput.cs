// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""ee8edf98-1780-4fb5-a40c-c10acf820bcf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""89a72e2f-9e73-4481-ba3f-fffade7fe30e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UpDownFly"",
                    ""type"": ""Value"",
                    ""id"": ""39da5765-bb4d-452c-86fd-f0d9a859538c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6d155dcf-726e-49a6-b8cd-369668e94bbb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""500d275a-e7df-47d9-bdc8-b5b80c3da9bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugButton"",
                    ""type"": ""Button"",
                    ""id"": ""de9aae60-ce52-45e8-b9cd-e560716054db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugButton2"",
                    ""type"": ""Button"",
                    ""id"": ""aea7bb61-2806-45cd-b5c9-dd35a82c16e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""dc366b4a-6ed1-4cc9-9254-0febfc191674"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""636b5656-4743-4870-a2b7-a29dc83b8bb8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f3d9af8d-0da7-40d4-ac13-97b810512b35"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f67f255c-40a0-4f15-9ff1-2c5e39ab7f94"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d623e4e0-f38b-4696-8698-e66984491afa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f21c9781-9215-46a5-8c84-87c8df30758c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDownFly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4d59e4c2-737c-4e86-b083-4d1af1ff2220"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDownFly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""da9429cb-46ac-44f3-a09e-ab0443dc3862"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDownFly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d9bebe53-6b0f-4a1d-8522-b462bc3d9695"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""230ee539-7f6d-4e3b-993f-9e9a56e89e7f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cca41a89-cd81-48b0-bc01-15b1abc951f9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60ddb1d5-c05c-4fc9-be13-e67f44fe1e8f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugButton2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Movement = m_Camera.FindAction("Movement", throwIfNotFound: true);
        m_Camera_UpDownFly = m_Camera.FindAction("UpDownFly", throwIfNotFound: true);
        m_Camera_Rotation = m_Camera.FindAction("Rotation", throwIfNotFound: true);
        m_Camera_Sprint = m_Camera.FindAction("Sprint", throwIfNotFound: true);
        m_Camera_DebugButton = m_Camera.FindAction("DebugButton", throwIfNotFound: true);
        m_Camera_DebugButton2 = m_Camera.FindAction("DebugButton2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_Movement;
    private readonly InputAction m_Camera_UpDownFly;
    private readonly InputAction m_Camera_Rotation;
    private readonly InputAction m_Camera_Sprint;
    private readonly InputAction m_Camera_DebugButton;
    private readonly InputAction m_Camera_DebugButton2;
    public struct CameraActions
    {
        private @PlayerInput m_Wrapper;
        public CameraActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Camera_Movement;
        public InputAction @UpDownFly => m_Wrapper.m_Camera_UpDownFly;
        public InputAction @Rotation => m_Wrapper.m_Camera_Rotation;
        public InputAction @Sprint => m_Wrapper.m_Camera_Sprint;
        public InputAction @DebugButton => m_Wrapper.m_Camera_DebugButton;
        public InputAction @DebugButton2 => m_Wrapper.m_Camera_DebugButton2;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMovement;
                @UpDownFly.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnUpDownFly;
                @UpDownFly.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnUpDownFly;
                @UpDownFly.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnUpDownFly;
                @Rotation.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotation;
                @Rotation.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotation;
                @Rotation.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotation;
                @Sprint.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnSprint;
                @DebugButton.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnDebugButton;
                @DebugButton.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnDebugButton;
                @DebugButton.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnDebugButton;
                @DebugButton2.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnDebugButton2;
                @DebugButton2.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnDebugButton2;
                @DebugButton2.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnDebugButton2;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @UpDownFly.started += instance.OnUpDownFly;
                @UpDownFly.performed += instance.OnUpDownFly;
                @UpDownFly.canceled += instance.OnUpDownFly;
                @Rotation.started += instance.OnRotation;
                @Rotation.performed += instance.OnRotation;
                @Rotation.canceled += instance.OnRotation;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @DebugButton.started += instance.OnDebugButton;
                @DebugButton.performed += instance.OnDebugButton;
                @DebugButton.canceled += instance.OnDebugButton;
                @DebugButton2.started += instance.OnDebugButton2;
                @DebugButton2.performed += instance.OnDebugButton2;
                @DebugButton2.canceled += instance.OnDebugButton2;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface ICameraActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnUpDownFly(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnDebugButton(InputAction.CallbackContext context);
        void OnDebugButton2(InputAction.CallbackContext context);
    }
}
