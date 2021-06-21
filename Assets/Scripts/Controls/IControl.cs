using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControl
{
    public delegate void OnPress();
    public event OnPress OnPressEvent;

    public delegate void OnRelease();
    public event OnRelease OnReleaseEvent;

    void Initialize();
    Vector2 GetPointerPosition();
    Vector2 GetPointerDelta();
    void Enable();
    void Disable();
}
