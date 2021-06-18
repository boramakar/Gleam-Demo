using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    PlayerInputs playerInputs;
    bool followingPointer;

    //Throwable Details
    GameObject objectPreview;

    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPreview = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (followingPointer)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    void ShootThrowable()
    {
        objectPreview.SetActive(false);
    }

    void UpdateThrowable(ThrowableData data)
    {

    }
}
