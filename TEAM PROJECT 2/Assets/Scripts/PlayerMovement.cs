using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //..............................................Variables
    public CharacterController controller;
    public float moveSpeed = 10f;

    void Update()
    {
        //..............................................Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //..............................................Move player
        //creates a location to move to relative to 
        //direction player is facing
        Vector3 newLocation = transform.right * x + transform.forward * z;

        controller.Move(newLocation * moveSpeed * Time.deltaTime);
    }
}
