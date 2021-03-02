using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))] //Required for the script to run
[RequireComponent(typeof(TankMotor))] //Required for the script to run
[RequireComponent(typeof(TankShooter))] //Required for the script to run
public class AIObstacleAvoidanceController : MonoBehaviour
{
    private TankData data; //Tank Data Component
    private TankMotor motor; //Tank Motor Component
    private TankShooter shooter; //Tank Shooter Component

    public enum attackState { Chase };
    public attackState AttackState = attackState.Chase;

    public enum avoidance { NotAvoiding, ObstacleDetected, AvoidingObstacle };
    public avoidance Avoidance = avoidance.NotAvoiding;
    public float avoidtime = 2.0f;
    private float exitTime = 2.0f;
    public float closeEnough = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        shooter = GetComponent<TankShooter>();

    }

    private void Update()
    {
        if (AttackState == attackState.Chase)
        {
            if (Avoidance != avoidance.NotAvoiding)
            {
                Avoid();
            }
            else
            {
               Chase(GameManager.Instance.Players[0]);
            }
            //Do the chase behavoir
        }
    }
    public void Chase(GameObject target)
    {
        if (motor.RotateTowards(target.transform.position, data.turnSpeed))
        {
            //Do Nothing
        }
        else if (!CanMove(data.moveSpeed))
        {
            Avoidance = avoidance.ObstacleDetected;
        }
        else
        {
            if (Vector3.SqrMagnitude(transform.position - target.transform.position) >= (closeEnough * closeEnough))
            {
                motor.Move(data.moveSpeed);
            }
            else
            {
                //Do Nothing
            }

        }
    }

    public void Avoid()
    {
        if (Avoidance == avoidance.ObstacleDetected)
        {
            motor.Rotate(-1 * data.turnSpeed);
            if (CanMove(data.moveSpeed))
            {
                Avoidance = avoidance.AvoidingObstacle;
                exitTime = avoidtime;
            }
        }

        else if (Avoidance == avoidance.AvoidingObstacle)
        {
            
        }
        else
        {

        }

    }

    bool CanMove(float speed)
    {
        // Cast a ray forward in the distance that we sent in
        RaycastHit hit;

        // If our raycast hit something...
        if (Physics.Raycast(transform.position, transform.forward, out hit, speed))
        {
            // ... and if what we hit is not the player...
            if (!hit.collider.CompareTag("Player"))
            {
                // ... then we can't move
                return false;
            }
        }
        return true;
    }
}
