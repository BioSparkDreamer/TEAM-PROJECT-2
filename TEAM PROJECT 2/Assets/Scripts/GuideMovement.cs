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
    }

    void Update()
    {
        if (startMovement == true)
        {
            //...............................................Check if waypoint reached
            if (gameObject.transform.position == waypoint[waypointIndex].transform.position)
            {
                //Set next waypoint in array as new target,
                //check if it has a waypointadjuster script
                waypointIndex = waypointIndex + 1;
                GameObject waypointScriptCheck = waypoint[waypointIndex].gameObject;
                waypointScriptCheck.GetComponent<WaypointAdjuster>();

                //If it does, grab its values to change how
                //the guide moves
                if (waypointScriptCheck != null)
                {
                    
                }
                else
                {
                    moveSpeed = defaultMoveSpeed;
                    waitTime = 0f;
                }

                //start moving toward next waypoint
                MoveToWaypoint();
            }
            else
            {
                MoveToWaypoint();
            }
            
        }
    }

    void MoveToWaypoint()
    {
        //...............................................Pause movement
        if (waitTime < 0f)
        {
            waitTime = waitTime - Time.deltaTime;
            return;
        }

        //...............................................Move toward waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoint[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
    }
}
