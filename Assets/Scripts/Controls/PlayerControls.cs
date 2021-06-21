using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class PlayerControls : IControl
{
    public event IControl.OnPress OnPressEvent;
    public event IControl.OnRelease OnReleaseEvent;

    PlayerInputs playerInputs;

    // Start is called before the first frame update
    public void Initialize()
    {
        playerInputs = new PlayerInputs();
        playerInputs.Gameplay.Press.performed += Press;
        playerInputs.Gameplay.Release.performed += Release;
    }

    public Vector2 GetPointerPosition()
    {
        return playerInputs.Gameplay.Position.ReadValue<Vector2>(); ;
    }
    public Vector2 GetPointerDelta()
    {
        return playerInputs.Gameplay.Delta.ReadValue<Vector2>(); ;
    }

    void Press(InputAction.CallbackContext context)
    {
        if (OnPressEvent != null)
            OnPressEvent();
    }

    void Release(InputAction.CallbackContext context)
    {
        if (OnReleaseEvent != null)
            OnReleaseEvent();
    }

    public void Enable()
    {
        playerInputs.Enable();
    }

    public void Disable()
    {
        playerInputs.Disable();
    }
}
