using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class ThrowableBox : SerializedMonoBehaviour, IThrowable
{
    ThrowableData currentData;
    MeshRenderer meshRenderer;

    Rigidbody rb;

    GameManager gameManager;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        gameManager = GameManager.Instance;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
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
        meshRenderer.material = data.material;
        meshRenderer.material.color = data.color;
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
                    //Remove other object
                    other.gameObject.SetActive(false);
                    gameManager.ReturnThrowable(other.gameObject);
                    //Merge and Jump
                    rb.AddForce(Vector3.up * gameManager.jumpForce);
                    rb.AddForce(Vector3.forward * gameManager.magnetForce);
                    //Update max value in case the product is the new highest
                    int newValue = currentData.value * 2;
                    gameManager.UpdateMaxProducedValue(newValue);
                    //Update visuals to new value
                    UpdateData(gameManager.GetThrowableData(newValue));
                }
            }
        }
    }

    public GameObject GetGameObject()
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
