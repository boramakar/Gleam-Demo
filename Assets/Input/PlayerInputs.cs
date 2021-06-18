// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""11f3f0a6-54a1-4cef-adea-13506542e859"",
            ""actions"": [
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""eba9a62a-111b-41e2-88fe-b4f9468686e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Release"",
                    ""type"": ""Button"",
                    ""id"": ""33c0107c-8ca5-4611-90cc-0971258ba965"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""8a441c10-f374-4ebe-bc0d-ff3f6c081e99"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8865df6e-ff0d-444d-8dd8-263c583b4917"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75bdd9f6-07c4-4495-81d5-517e427686d4"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99751482-a9b9-4195-a287-55b161842b1b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4d03d05-0ee6-42d8-9e2a-f613602f3462"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Release"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de9aa083-4f2f-4e89-b80a-4b2ea427b942"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c53ca4c-7a86-4799-a620-4345bbc55216"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Press = m_Gameplay.FindAction("Press", throwIfNotFound: true);
        m_Gameplay_Release = m_Gameplay.FindAction("Release", throwIfNotFound: true);
        m_Gameplay_Position = m_Gameplay.FindAction("Position", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Press;
    private readonly InputAction m_Gameplay_Release;
    private readonly InputAction m_Gameplay_Position;
    public struct GameplayActions
    {
        private @PlayerInputs m_Wrapper;
        public GameplayActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Press => m_Wrapper.m_Gameplay_Press;
        public InputAction @Release => m_Wrapper.m_Gameplay_Release;
        public InputAction @Position => m_Wrapper.m_Gameplay_Position;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Press.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPress;
                @Press.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPress;
                @Press.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPress;
                @Release.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRelease;
                @Release.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRelease;
                @Release.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRelease;
                @Position.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                @Position.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
                @Position.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPosition;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Press.started += instance.OnPress;
                @Press.performed += instance.OnPress;
                @Press.canceled += instance.OnPress;
                @Release.started += instance.OnRelease;
                @Release.performed += instance.OnRelease;
                @Release.canceled += instance.OnRelease;
                @Position.started += instance.OnPosition;
                @Position.performed += instance.OnPosition;
                @Position.canceled += instance.OnPosition;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnPress(InputAction.CallbackContext context);
        void OnRelease(InputAction.CallbackContext context);
        void OnPosition(InputAction.CallbackContext context);
    }
}
