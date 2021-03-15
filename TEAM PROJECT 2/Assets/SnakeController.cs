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


    private Vector3 startLocation;
    private Vector3 forwardPatrolLocation;
    private Vector3 backwardPatrolLocation;

    private bool moveTowardForwardPatrol = true;
    private Vector3 patrolLocationCheck;

    
    void Start()
    {
        //..............................................Instantiate
        snakeRigidBody = GetComponent<Rigidbody>();

        //..............................................Find start and patrol positions
        startLocation = transform.position;

        //calculates location based on local orientation, then uses TransformPoint to change that into a global position
        forwardPatrolLocation = transform.TransformPoint(Vector3.forward * patrolRadius);
        backwardPatrolLocation = transform.TransformPoint(Vector3.forward * -patrolRadius);
    }

    
    void Update()
    {
        //..............................................Rotation/Movement
        if (moveTowardForwardPatrol == true)
        {
            //check position
            patrolLocationCheck = forwardPatrolLocation;
            patrolLocationCheck.y = transform.position.y;
            if(Vector3.Distance(patrolLocationCheck, transform.position) < 1)
            {
                moveTowardForwardPatrol = false;
            }

            RotateTowardsLocation(forwardPatrolLocation);
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

            RotateTowardsLocation(backwardPatrolLocation);
        }

        MoveForward();
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


    void  MoveForward()
    {
        Vector3 currentSnakePosition = snakeRigidBody.position;

        Vector3 forwardLocation = currentSnakePosition + transform.forward * patrolSpeed * Time.deltaTime;
        snakeRigidBody.MovePosition(forwardLocation);
    }
}
