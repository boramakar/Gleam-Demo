using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Throwable Data", menuName = "Throwable Data")]
public class ThrowableData : ScriptableObject
{
    public Mesh mesh;
    public Material material;
    public Color color;
    public int fontSize;
    public int value;
}
