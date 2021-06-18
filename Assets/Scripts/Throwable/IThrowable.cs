using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public interface IThrowable
{
    public void UpdateData(ThrowableData data);
    public void Throw();
    public void OnTriggerEnter(Collider other);
    public int GetValue();
}