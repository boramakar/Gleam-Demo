using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    [SerializeField]
    IControl alternateControls;

    IControl controls;

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Awake()
    {
        if (alternateControls != null)
            controls = alternateControls;
        else
            controls = new PlayerControls();

        controls.Initialize();
    }

    public void SubscribePress(IControl.OnPress pressHandler)
    {
        controls.OnPressEvent += pressHandler;
    }

    public void SubscribeRelease(IControl.OnRelease releaseHandler)
    {
        controls.OnReleaseEvent += releaseHandler;
    }

    public void UnsubscribePress(IControl.OnPress pressHandler)
    {
        controls.OnPressEvent -= pressHandler;
    }

    public void UnsubscribeRelease(IControl.OnRelease releaseHandler)
    {
        controls.OnReleaseEvent -= releaseHandler;
    }

    public Vector2 GetPosition()
    {
        return controls.GetPointerPosition();
    }

    public Vector2 GetDelta()
    {
        return controls.GetPointerDelta();
    }
}
