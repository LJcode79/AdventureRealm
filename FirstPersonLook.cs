﻿using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    public float sensitivity = 2;
    public float smoothing = 1.5f;
    bool lockedState = true;
    Vector2 velocity;
    Vector2 frameVelocity;


    //oid Reset()
    //{
        // Get the character from the FirstPersonMovement in parents.
        //character = GetComponentInParent<FirstPersonMovement>().transform;
   // }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void turnOffLock()
    {
        Cursor.visible = true;
        lockedState = false;
        Cursor.lockState = CursorLockMode.None;
    }

    public void toggleLock()
    {
        if (lockedState == true)
        {
            //Debug.Log("toggled");
            Cursor.visible = true;
            lockedState = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            lockedState = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Debug.Log("toggled");
            toggleLock();
        }
    }

    /**
    void Update()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }
    **/
}
