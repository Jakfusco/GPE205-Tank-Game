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

    //TODO: We need a way to track all waypoints
    public GameObject[] waypoints;
    public float closeEnough = 1.0f;
    //TODO: We need to figure out what waypoint we are at
    private int currentWaypoint = 0;
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
        if (motor.RotateTowards(waypoints[currentWaypoint].transform.position,data.turnSpeed))
        {
            //Do Nothing
        }
        else
        {
            motor.Move(data.moveSpeed);
        }
        //If we have arrived at the waypoint, advance to next way point
        if (Vector3.SqrMagnitude(transform.position - waypoints[currentWaypoint].transform.position) <= (closeEnough * closeEnough))
        {

        }
        
        if (Time.time >= lastEventTime + timerDelay)
        {
            shooter.shoot();
            lastEventTime = Time.time;
        }
    }

}
