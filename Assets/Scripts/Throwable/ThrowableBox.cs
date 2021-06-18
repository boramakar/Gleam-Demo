using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ThrowableBox : SerializedMonoBehaviour, IThrowable
{
    MeshFilter throwableMeshFilter;
    Material throwableMaterial;
    MeshRenderer throwableRenderer; //possibly redundant

    // Start is called before the first frame update
    void Start()
    {
        throwableMeshFilter = gameObject.GetComponent<MeshFilter>();
        throwableRenderer = gameObject.GetComponent<MeshRenderer>();
        throwableMaterial = throwableRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMasks.BoxLayer)
        {

        }
    }

    public void UpdateData(ThrowableData data)
    {
        throw new System.NotImplementedException();
    }

    public void Throw()
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IThrowable>().GetValue() == GetValue())
        {

        }
    }

    public int GetValue()
    {
        throw new System.NotImplementedException();
    }
}
