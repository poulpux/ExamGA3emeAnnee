//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/InputSystemManette.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputSystemManette: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystemManette()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystemManette"",
    ""maps"": [
        {
            ""name"": ""Control"",
            ""id"": ""2b0d9850-97b8-4e4f-8d31-5d4a3ff669db"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e5b0a2ee-5fbb-481e-acd6-fd31567773fd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SwitchCardLeft"",
                    ""type"": ""Button"",
                    ""id"": ""39e2f03c-c6e8-4b0d-a9ab-aaae7dbfc22c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchCardRight"",
                    ""type"": ""Button"",
                    ""id"": ""ab9ee107-9302-4d7a-9d7f-5b4413256b66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Invoque"",
                    ""type"": ""Button"",
                    ""id"": ""71729bdf-37b3-460b-ba15-c2936e54c7eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1aa00563-9c1e-489e-972f-605236a0d5de"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""68fb66c8-a532-49b4-abf8-fd1cd8820c6b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b9432d59-5f6e-4bd7-bbe6-87c84ee69fcd"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e86d01f5-a26d-497a-9c5a-1bbf2e8b8d53"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""49a6f936-68b6-450d-99a1-55360512c2f3"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f1c300ef-c4de-4433-ad98-9d48b9b4bbd0"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5e6552d3-46f3-435e-a532-447817337243"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCardLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4d361a1-5384-4426-9d5f-b7f471ee0ec2"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCardLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39e86c9d-08de-4317-b35a-4d2e164a1e32"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCardRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6d8eed9-02fb-4758-9200-d8e3d0eb358b"",
                    ""path"": ""<Keyboard>/numpad9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchCardRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8fe39a3-3025-4c02-8a39-af43ab612f74"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Invoque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c9a3361-d40b-4de2-8411-25a660cebf01"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Invoque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Control
        m_Control = asset.FindActionMap("Control", throwIfNotFound: true);
        m_Control_Move = m_Control.FindAction("Move", throwIfNotFound: true);
        m_Control_SwitchCardLeft = m_Control.FindAction("SwitchCardLeft", throwIfNotFound: true);
        m_Control_SwitchCardRight = m_Control.FindAction("SwitchCardRight", throwIfNotFound: true);
        m_Control_Invoque = m_Control.FindAction("Invoque", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Control
    private readonly InputActionMap m_Control;
    private List<IControlActions> m_ControlActionsCallbackInterfaces = new List<IControlActions>();
    private readonly InputAction m_Control_Move;
    private readonly InputAction m_Control_SwitchCardLeft;
    private readonly InputAction m_Control_SwitchCardRight;
    private readonly InputAction m_Control_Invoque;
    public struct ControlActions
    {
        private @InputSystemManette m_Wrapper;
        public ControlActions(@InputSystemManette wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Control_Move;
        public InputAction @SwitchCardLeft => m_Wrapper.m_Control_SwitchCardLeft;
        public InputAction @SwitchCardRight => m_Wrapper.m_Control_SwitchCardRight;
        public InputAction @Invoque => m_Wrapper.m_Control_Invoque;
        public InputActionMap Get() { return m_Wrapper.m_Control; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlActions set) { return set.Get(); }
        public void AddCallbacks(IControlActions instance)
        {
            if (instance == null || m_Wrapper.m_ControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ControlActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @SwitchCardLeft.started += instance.OnSwitchCardLeft;
            @SwitchCardLeft.performed += instance.OnSwitchCardLeft;
            @SwitchCardLeft.canceled += instance.OnSwitchCardLeft;
            @SwitchCardRight.started += instance.OnSwitchCardRight;
            @SwitchCardRight.performed += instance.OnSwitchCardRight;
            @SwitchCardRight.canceled += instance.OnSwitchCardRight;
            @Invoque.started += instance.OnInvoque;
            @Invoque.performed += instance.OnInvoque;
            @Invoque.canceled += instance.OnInvoque;
        }

        private void UnregisterCallbacks(IControlActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @SwitchCardLeft.started -= instance.OnSwitchCardLeft;
            @SwitchCardLeft.performed -= instance.OnSwitchCardLeft;
            @SwitchCardLeft.canceled -= instance.OnSwitchCardLeft;
            @SwitchCardRight.started -= instance.OnSwitchCardRight;
            @SwitchCardRight.performed -= instance.OnSwitchCardRight;
            @SwitchCardRight.canceled -= instance.OnSwitchCardRight;
            @Invoque.started -= instance.OnInvoque;
            @Invoque.performed -= instance.OnInvoque;
            @Invoque.canceled -= instance.OnInvoque;
        }

        public void RemoveCallbacks(IControlActions instance)
        {
            if (m_Wrapper.m_ControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IControlActions instance)
        {
            foreach (var item in m_Wrapper.m_ControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ControlActions @Control => new ControlActions(this);
    public interface IControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSwitchCardLeft(InputAction.CallbackContext context);
        void OnSwitchCardRight(InputAction.CallbackContext context);
        void OnInvoque(InputAction.CallbackContext context);
    }
}
