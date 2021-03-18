using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ================= TO USE: ===================
// While "startMovement" is true, this script will run. It will turn it off
// at the end. In the unity inspector, you can set any number of waypoints that
// you want the object this script is attached to to move towards, in order.
// If you attach the "WaypointAdjuster" script to those objects, you can modify
// how this object will move towards them individually.


public class GuideMovement : MonoBehaviour
{
    //.............................................Waypoint Variables
    public Transform[] waypoint;
    int waypointIndex = 0;
    private WaypointAdjuster waypointAdjuster;

    private float moveSpeed;
    private float waitTime = 0;

    //.............................................Movement Variables
    public float defaultMoveSpeed = 5f;
    public bool startMovement = false;

    //.............................................Animation
    Animator anim;
    
    
    
    void Start()
    {
        //.............................................Instantiation
        moveSpeed = defaultMoveSpeed;
        //checks first waypoint in array for a
        //script, adds its modifications if applicable
        CheckWaypoint();

        anim = GetComponent<Animator>();

        
    }

    void Update()
    {
        //.............................................Turn on movement
        if (startMovement == true)
        {
            //check if current destination reached
            if (gameObject.transform.position == waypoint[waypointIndex].transform.position)
            {
                //.............................................Set next waypoint in array as new target
                if (waypointIndex < waypoint.Length - 1)
                {
                    waypointIndex = waypointIndex + 1;
                    //check if it has a WaypointAdjuster script
                    CheckWaypoint();
                }
                //...............................................Turn off movement at end of array
                else
                {
                    waypointIndex = 0;
                    startMovement = false;
                }
            }
            MoveToWaypoint();
        }
    }

    void CheckWaypoint()
    {
        //check if waypoint has a WaypointAdjuster script
        GameObject waypointScriptCheck = waypoint[waypointIndex].gameObject;
        waypointAdjuster = waypointScriptCheck.GetComponent<WaypointAdjuster>();

        //If it does, grab its values to change how
        //the guide will move
        if (waypointScriptCheck != null)
        {
            moveSpeed = waypointAdjuster.aproachSpeed;
            waitTime = waypointAdjuster.waitThenCome;
        }
        else
        {
            moveSpeed = defaultMoveSpeed;
            waitTime = 0f;
        }
    }

    void MoveToWaypoint()
    {
        //Pause movement if there is a wait time
        if (waitTime > 0f)
        {
            anim.SetInteger("State", 0);
            waitTime = waitTime - Time.deltaTime;
            return;
        }
        else
        {
            //Move toward waypoint
            anim.SetInteger("State", 1);
            transform.position = Vector3.MoveTowards(transform.position, waypoint[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        }
    }

}
