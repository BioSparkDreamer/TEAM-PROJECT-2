using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Scene numbers
//Main Menu 0
//About 1
//Inside Temple 2
//Outside Temple 3
//Game Over 4
//Win 5

// =================NOTE=====================
// The ground checker only looks at objects tagged
// with the "Ground" layer (to keep it from checking 
// itself). Any terrain you want the player to walk
// on should have the "Ground" layer on them.

public class PlayerMovement : MonoBehaviour
{
    //..............................................Variables
    public CharacterController controller;
    int count = 0;

    //..............................................Movement 
    public float moveSpeed = 10f;

    public float gravity = -9.81f;
    Vector3 fallVelocity;

    public Transform groundCheck;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpStrength = 3f;

    //..............................................Health Bar Configuration
    public Object fullHealth;
    public Object halfHealth;

    //..............................................Audio
    public AudioSource barkAudio;
    public AudioSource jumpAudio;
    public AudioSource walkAudio;

    void Start()
    {
        fullHealth = GameObject.FindGameObjectWithTag("Full Health");
        halfHealth = GameObject.FindGameObjectWithTag("Half Health");
    }

    void Update()
    {
        //..............................................Ground check/Fall velocity reset
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
        //resets fall velocity to a small number if close
        if(isGrounded && fallVelocity.y < 0)
        {
            fallVelocity.y = -2f;
        }
        //..............................................Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        FootstepAudioCheck(x, z);


        //..............................................Move player
        //creates a location to move to relative to 
        //direction player is facing
        Vector3 newLocation = transform.right * x + transform.forward * z;

        controller.Move(newLocation * moveSpeed * Time.deltaTime);

        //..............................................Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            fallVelocity.y = Mathf.Sqrt(jumpStrength * -2f * gravity);
            jumpAudio.Play();
        }

        //..............................................Player fall velocity
        //Note: multiplied by Time.deltaTime twice 
        //because that's just how physics works man
        fallVelocity.y = fallVelocity.y + gravity * Time.deltaTime;
        controller.Move(fallVelocity * Time.deltaTime);
    }

    //..............................................Snake Damage
    public void OnCollisionEnter(Collision other)
    {

        //..........................................Snake dmg
        if (other.gameObject.tag == "Snake")
        {
            Destroy(fullHealth);

            if (count == 1)
            {
                Destroy(halfHealth);
            }

            if (count == 2)
            {
                SceneManager.LoadScene(4);
            }

            count += 1;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        //..........................................Conditional for getting inside Temple
        if(other.gameObject.tag == "Entrance")
        {
            if (PlayerRunes.runes == 3)
            {
                SceneManager.LoadScene(2);
            }
        }

        else if(other.gameObject.tag == "Well")
        {
            SceneManager.LoadScene(5);
        }
    }
    void FootstepAudioCheck(float x, float z)
    {
        if (isGrounded == true)
        {
            float absx = Mathf.Abs(x);
            float absz = Mathf.Abs(z);

            if (absx > 0 || absz > 0)
            {
                PlayWalkAudio();
            }
            else
            {
                StopWalkAudio();
            }
        }
        else if (isGrounded == false)
        {
            StopWalkAudio();
        }
    }

    void PlayWalkAudio()
    {
        if (walkAudio.isPlaying == false)
        {
            walkAudio.Play();
        }
    }

    void StopWalkAudio()
    {
        if (walkAudio.isPlaying == true)
        {
            walkAudio.Stop();
        }
    }
}
