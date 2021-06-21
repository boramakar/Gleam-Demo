using System;
using System.Collections.Generic;
using UnityEngine;

public interface IThrowable
{
    public void UpdateData(ThrowableData data);
    public void Throw();
    public void OnTriggerEnter(Collider other);
    public int GetValue();
    public GameObject GetGameObject();
    public bool IsActive();
    public Vector3 GetVelocity();
    public void LockTransformations();
}