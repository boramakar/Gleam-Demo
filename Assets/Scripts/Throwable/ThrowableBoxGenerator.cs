using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

class ThrowableBoxGenerator : SerializedMonoBehaviour, IThrowableGenerator
{
    [AssetList(Path = "Prefabs/Throwable/Box/Data", AutoPopulate = true)]
    [SerializeField]
    List<ThrowableData> boxDataList;

    void Awake()
    {
        UnityEngine.Random.InitState(DateTime.Now.Millisecond); //Something to make games more random, hopefully it works fine
    }

    public ThrowableData GenerateThrowable(int minValue, int maxValue)
    {
        ThrowableData data;
        data = boxDataList[UnityEngine.Random.Range((int)(Mathf.Log(minValue, 2)) - 1, (int)(Mathf.Log(maxValue, 2)) - 1)];
        Debug.Log("Generated throwable: " + data);
        return data;
    }
}
