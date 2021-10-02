// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerKeyboardInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerKeyboardInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerKeyboardInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerKeyboardInput"",
    ""maps"": [
        {
            ""name"": ""Player1"",
            ""id"": ""5e9913b8-ada4-465c-8e51-10a9b7aab83f"",
            ""actions"": [
                {
                    ""name"": ""UpDownArrows"",
                    ""type"": ""Button"",
                    ""id"": ""6db4dc19-e6c0-4467-a225-e2dd878a3fc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""type"": ""Button"",
                    ""id"": ""ff616406-0a17-47d2-861c-0ae63663449a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2af67c6d-894a-45d3-b2be-cd878366bc5a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDownArrows"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""031010a2-ceac-4bdd-a056-cbe77f7eeed0"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDownArrows"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7e051729-93d7-4791-8048-8068b714109a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDownArrows"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6d94eca6-90d5-47fb-bf59-9a80f59fd383"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""42ae7d94-4456-4db7-926d-18d915c3e4a4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f6e3f6fd-2ca2-4e80-b8ef-842013f1d151"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArrowKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""9fb97f95-74f5-4132-bf23-92ff63e24b15"",
            ""actions"": [
                {
                    ""name"": ""WSKeys"",
                    ""type"": ""Button"",
                    ""id"": ""374d8fff-b8bf-455f-a2ad-0701c8ada488"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WASD"",
                    ""type"": ""Button"",
                    ""id"": ""aa27c89c-2f61-497f-8333-8de890b7da9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1d6efae3-4a70-4921-a415-ed01df423031"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WSKeys"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""11e63799-0e04-4a58-a0ea-eddecbb2e12e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WSKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""897f86ce-2f8a-48a8-806e-c42c333265d8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WSKeys"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a189049e-2a15-40e7-8df0-6721ff8a25c5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1b98b01e-8374-495d-82ff-d28cb699cfa8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2b3dd9ca-f1fc-4db3-9ac6-67af4cbf029b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player1
        m_Player1 = asset.FindActionMap("Player1", throwIfNotFound: true);
        m_Player1_UpDownArrows = m_Player1.FindAction("UpDownArrows", throwIfNotFound: true);
        m_Player1_ArrowKeys = m_Player1.FindAction("ArrowKeys", throwIfNotFound: true);
        // Player2
        m_Player2 = asset.FindActionMap("Player2", throwIfNotFound: true);
        m_Player2_WSKeys = m_Player2.FindAction("WSKeys", throwIfNotFound: true);
        m_Player2_WASD = m_Player2.FindAction("WASD", throwIfNotFound: true);
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

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_UpDownArrows;
    private readonly InputAction m_Player1_ArrowKeys;
    public struct Player1Actions
    {
        private @PlayerKeyboardInput m_Wrapper;
        public Player1Actions(@PlayerKeyboardInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpDownArrows => m_Wrapper.m_Player1_UpDownArrows;
        public InputAction @ArrowKeys => m_Wrapper.m_Player1_ArrowKeys;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                @UpDownArrows.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUpDownArrows;
                @UpDownArrows.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUpDownArrows;
                @UpDownArrows.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnUpDownArrows;
                @ArrowKeys.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnArrowKeys;
                @ArrowKeys.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnArrowKeys;
                @ArrowKeys.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnArrowKeys;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UpDownArrows.started += instance.OnUpDownArrows;
                @UpDownArrows.performed += instance.OnUpDownArrows;
                @UpDownArrows.canceled += instance.OnUpDownArrows;
                @ArrowKeys.started += instance.OnArrowKeys;
                @ArrowKeys.performed += instance.OnArrowKeys;
                @ArrowKeys.canceled += instance.OnArrowKeys;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_WSKeys;
    private readonly InputAction m_Player2_WASD;
    public struct Player2Actions
    {
        private @PlayerKeyboardInput m_Wrapper;
        public Player2Actions(@PlayerKeyboardInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @WSKeys => m_Wrapper.m_Player2_WSKeys;
        public InputAction @WASD => m_Wrapper.m_Player2_WASD;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                @WSKeys.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWSKeys;
                @WSKeys.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWSKeys;
                @WSKeys.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWSKeys;
                @WASD.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWASD;
                @WASD.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWASD;
                @WASD.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnWASD;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WSKeys.started += instance.OnWSKeys;
                @WSKeys.performed += instance.OnWSKeys;
                @WSKeys.canceled += instance.OnWSKeys;
                @WASD.started += instance.OnWASD;
                @WASD.performed += instance.OnWASD;
                @WASD.canceled += instance.OnWASD;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    public interface IPlayer1Actions
    {
        void OnUpDownArrows(InputAction.CallbackContext context);
        void OnArrowKeys(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnWSKeys(InputAction.CallbackContext context);
        void OnWASD(InputAction.CallbackContext context);
    }
}
