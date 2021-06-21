using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New Throwable Data", menuName = "Throwable Data")]
public class ThrowableData : SerializedScriptableObject
{
    [TitleGroup("Box Properties")]
    public int value;
    [BoxGroup("Visuals")]
    public GameObject prefab;
    [BoxGroup("Visuals")]
    public Mesh mesh;
    [BoxGroup("Visuals")]
    public Material material;
    [BoxGroup("Visuals")]
    public Color color;
    [BoxGroup("Visuals")]
    public float fontSize;
}
