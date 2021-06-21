using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class ThrowableBox : SerializedMonoBehaviour, IThrowable
{
    ThrowableData currentData;
    Material material;

    Rigidbody rb;

    GameManager gameManager;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        gameManager = GameManager.Instance;
        material = gameObject.GetComponent<MeshRenderer>().material;
    }

    public void UpdateData(ThrowableData data)
    {
        currentData = data;
        for(int i = 0; i < transform.childCount; i++)
        {
            var textMesh = transform.GetChild(i).GetComponent<TextMeshPro>();
            textMesh.text = data.value.ToString();
            textMesh.fontSize = data.fontSize;
        }
        material = data.material;
        material.color = data.color;
    }

    public void Throw()
    {
        rb.AddForce(Vector3.forward * gameManager.throwForce);
    }

    public int GetValue()
    {
        return currentData.value;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMasks.ThrowableLayer)
        {
            Debug.Log("Box trigger enter: " + other);
            if (other.GetComponent<IThrowable>().GetValue() == GetValue())
            {
                //Decide which object to keep and which one to disable
                if (rb.velocity.magnitude < other.GetComponent<IThrowable>().GetVelocity().magnitude) //Slower object should persist and jump
                {
                    rb.AddForce(Vector3.up * gameManager.jumpForce);
                    rb.AddForce(Vector3.forward * gameManager.magnetForce);
                    //Merge and Jump
                }
                else
                {
                    gameManager.ReturnThrowable(gameObject);
                }
            }
        }
    }

    public GameObject GetPrefab()
    {
        return gameObject;
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public Vector3 GetVelocity()
    {
        return rb.velocity;
    }
    public void LockTransformations()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
