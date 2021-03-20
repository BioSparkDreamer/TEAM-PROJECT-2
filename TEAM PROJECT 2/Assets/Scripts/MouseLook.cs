using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //..............................................Movement variables
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;

    void Start()
    {
        //..............................................Lock player cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        //..............................................Get input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //..............................................Left/right (rotates Player object)
        playerBody.Rotate(0f, 1f * mouseX, 0f);

        //..............................................Up/Down (ONLY rotates this camera)
        //Get a target rotation position, then prevent 
        //it from going too far (straight up and 
        //straight down)
        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
