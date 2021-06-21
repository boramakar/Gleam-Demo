using System;
using System.Collections.Generic;
using UnityEngine;

public interface IThrowableGenerator
{
    public ThrowableData GenerateThrowable(int min, int max);
}

