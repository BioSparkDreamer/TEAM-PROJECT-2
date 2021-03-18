using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    //..............................................Variables
    public float patrolRadius = 20f;
    public Rigidbody snakeRigidBody;
    public float patrolSpeed = 5f;
    public float rotateSpeed = 2f;

    public float startChaseRange = 10f;
    public float maxChaseRange = 40f;
    public float chaseSpeed = 8f;
    private bool chasingPlayer = false;
    public bool isFrozen = false;
    public float freezeTimer;


    private Vector3 startLocation;
    private Vector3 forwardPatrolLocation;
    private Vector3 backwardPatrolLocation;

    private bool moveTowardForwardPatrol = true;
    private Vector3 patrolLocationCheck;

    private Transform playerObjectTransform;

    public AudioSource hissHiss;


    void Start()
    {
        //..............................................Instantiate
        snakeRigidBody = GetComponent<Rigidbody>();

        //finds the player script by looking for a "PlayerRunes" tag
        GameObject playerObject = GameObject.FindWithTag("PlayerRunes");
        playerObjectTransform = playerObject.GetComponent<Transform>();

        //..............................................Find start and patrol positions
        startLocation = transform.position;

        //calculates location based on local orientation, then uses TransformPoint to change that into a global position
        forwardPatrolLocation = transform.TransformPoint(Vector3.forward * patrolRadius);
        backwardPatrolLocation = transform.TransformPoint(Vector3.forward * -patrolRadius);
    }


    void Update()
    {
        //..............................................Check Player Location
        if (Vector3.Distance(playerObjectTransform.position, transform.position) < startChaseRange && chasingPlayer == false)
        {
            chasingPlayer = true;
        }

        if (Vector3.Distance(playerObjectTransform.position, startLocation) > maxChaseRange && chasingPlayer == true)
        {
            chasingPlayer = false;
        }

        //..............................................Check Patrol Points
        if (moveTowardForwardPatrol == true)
        {
            //check position
            patrolLocationCheck = forwardPatrolLocation;
            patrolLocationCheck.y = transform.position.y;
            if (Vector3.Distance(patrolLocationCheck, transform.position) < 1)
            {
                moveTowardForwardPatrol = false;
            }
        }
        if (moveTowardForwardPatrol == false)
        {
            //check position
            patrolLocationCheck = backwardPatrolLocation;
            patrolLocationCheck.y = transform.position.y;
            if (Vector3.Distance(patrolLocationCheck, transform.position) < 1)
            {
                moveTowardForwardPatrol = true;
            }
        }
        if (chasingPlayer == true)
        {
            PlayHissAudio();
        }
        else if (chasingPlayer == false)
        {
            StopHissAudio();
        }
        if (isFrozen)
        {
            snakeRigidBody.constraints = RigidbodyConstraints.FreezePosition;
        }
        if (isFrozen == false)
        {
            snakeRigidBody.constraints = RigidbodyConstraints.None;
        }
        if (isFrozen)
        {
        freezeTimer -= Time.deltaTime;
            if (freezeTimer < 0)
                isFrozen = false;
        }
    }

    private void StopHissAudio()
    {
        if (hissHiss.isPlaying == true)
        {
            hissHiss.Stop();
        }
    }

    private void PlayHissAudio()
    {
        if (hissHiss.isPlaying == false)
        {
            hissHiss.Play();
        }
    }

    private void FixedUpdate()
    {
        if (chasingPlayer == true)
        {
            RotateTowardsLocation(playerObjectTransform.position);
            MoveForward(chaseSpeed);
        }

        else
        {
            if (moveTowardForwardPatrol == true)
            {
                RotateTowardsLocation(forwardPatrolLocation);
                MoveForward(patrolSpeed);
            }

            else
            {
                RotateTowardsLocation(backwardPatrolLocation);
                MoveForward(patrolSpeed);
            }
        }
    }

    void RotateTowardsLocation(Vector3 patrolLocation)
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = patrolLocation - transform.position;

        // remove verticality
        targetDirection.y = 0;

        // The step size is equal to speed times frame time.
        float singleStep = rotateSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }


    void MoveForward(float speed)
    {
        Vector3 currentSnakePosition = snakeRigidBody.position;

        Vector3 forwardLocation = currentSnakePosition + transform.forward * speed * Time.deltaTime;
        snakeRigidBody.MovePosition(forwardLocation);
    }
        public void Freeze()
    {
        isFrozen = true;
        freezeTimer = 3;
    }
}
