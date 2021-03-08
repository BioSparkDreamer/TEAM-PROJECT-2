using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    
    
    void Start()
    {
        moveSpeed = defaultMoveSpeed;
        CheckWaypoint();
        
    }

    void Update()
    {
        if (startMovement == true)
        {            
            if (gameObject.transform.position == waypoint[waypointIndex].transform.position)
            {
                //...............................................Turn off movement at end
                if (waypointIndex == waypoint.Length)
                {
                    waypointIndex = 0;
                    startMovement = false;
                }

                //...............................................Check if waypoint reached
                else
                {
                    //Set next waypoint in array as new target
                    waypointIndex = waypointIndex + 1;
                    //check if it has a WaypointAdjuster script
                    CheckWaypoint();
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
            waitTime = waitTime - Time.deltaTime;
            return;
        }
        else
        {
            //Move toward waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoint[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        }
    }

}
