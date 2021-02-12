using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))] //Required for the script to run
[RequireComponent(typeof(TankMotor))] //Required for the script to run
[RequireComponent(typeof(TankShooter))] //Required for the script to run
public class AIController : MonoBehaviour
{
    // Variables
    private TankData data; //Tank Data Component
    private TankMotor motor; //Tank Motor Component
    private TankShooter shooter; //Tank Shooter Component

    //Timer Variables
    public float timerDelay = 1.50f;
    private float lastEventTime;

    //Loop
    public enum LoopType { stop, loop, pingpong }
    public LoopType loopType = LoopType.stop;

    //TODO: We need a way to track all waypoints
    public GameObject[] waypoints;
    public float closeEnough = 1.0f;
    //TODO: We need to figure out what waypoint we are at
    private int currentWaypoint = 0;
    private bool isLoopingForward = true;
    private bool isNotAtFinalWaypoint
    {
        get
        {
            return currentWaypoint < (waypoints.Length - 1);
        }
        
    }
    //TODO Set up a method. bool isNotAtFinalWaypoint = currentWaypoint < (waypoints.Length - 1);
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        shooter = GetComponent<TankShooter>();

        lastEventTime = Time.time - timerDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: We need to so see if we are already at the waypoint

        //If we are not rotated to face the waypoint, turn to face it
        if (motor.RotateTowards(waypoints[currentWaypoint].transform.position, data.turnSpeed))
        {
            //Do Nothing
        }
        else
        {
            motor.Move(data.moveSpeed);
        }
        //If we have arrived at the waypoint, advance to next way point

        //If the AI is to move aling its patrol once
        if (loopType == LoopType.stop)
        {
            if (currentWaypoint < (waypoints.Length - 1))
            {
                if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
                {
                    currentWaypoint++;
                }
            }
        }


        //If the AI is to loop its patrol
        else if (loopType == LoopType.loop)
        {
            if (isNotAtFinalWaypoint)
            {
                if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
                {
                    currentWaypoint++;
                }
                else
                {
                    currentWaypoint = 0;
                }
            }


    else if (loopType == LoopType.pingpong)
        {
            if (isLoopingForward == true)
            {
                if (isNotAtFinalWaypoint)
                {
                    if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
                    {
                        currentWaypoint++;
                    }
                    else
                    {
                        isLoopingForward = false;
                    }
                }

                else
                {
                    if (currentWaypoint > 0)
                    {
                        if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
                        {
                            currentWaypoint--;
                        }
                        else
                        {
                            isLoopingForward = true;
                        }
                    }
                    else
                    {
                        Debug.LogWarning("[AIController] unexpected loop type");
                    }
                    // The AI autoshoots
                    if (Time.time >= lastEventTime + timerDelay)
                    {
                        shooter.shoot();
                        lastEventTime = Time.time;
                    }
                }

                }
            }
        }
    }
}
