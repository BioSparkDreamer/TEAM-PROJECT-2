using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //..............................................Variables
    public CharacterController controller;
    public float moveSpeed = 10f;

    public int runes = 0;

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

        //..............................................Conditional to get into temple
        if(runes == 3)
        {
            SceneManager.LoadScene(1);
        }
    }
}
