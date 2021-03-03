using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // ...............................................Movement Variables
    private Rigidbody rigidBody;
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;
    
    float horizontal;
    float vertical;


    void Start()
    {
        // ...........................................Instantiate Movement
        rigidBody = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //...........................................Movement Detection
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        //...........................................Movement Action
        rigidBody.velocity = new Vector3(horizontal * playerSpeed, rigidBody.velocity.y, vertical * playerSpeed);
        print(horizontal);
    }
}
