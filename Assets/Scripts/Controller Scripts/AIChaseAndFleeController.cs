using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))] //Required for the script to run
[RequireComponent(typeof(TankMotor))] //Required for the script to run
[RequireComponent(typeof(TankShooter))] //Required for the script to run
[RequireComponent(typeof(Health))] //Required for the script to run
public class AIChaseAndFleeController : MonoBehaviour
{
    private TankData data; //Tank Data Component
    private TankMotor motor; //Tank Motor Component
    private TankShooter shooter; //Tank Shooter Component
    private Health health; //Tank Health Component
    public float fleeDistance = 1.0f;
    public float closeEnough = 4.0f;

    public enum attackState { chase, flee }
    public attackState AttackState = attackState.chase;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        shooter = GetComponent<TankShooter>();
        health = GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        if (AttackState == attackState.chase)
        {
            Chase(GameManager.Instance.Players[0]);
            if (health.currentHealth <= 3)
            {
                AttackState = attackState.flee;
            }
        }
        else if (AttackState == attackState.flee)
        {
            Flee(GameManager.Instance.Players[0]);
            if (health.currentHealth > 3)
            {
                AttackState = attackState.flee;
            }
        }
        else
        {
            Debug.LogWarning("[AIChaseAndFleeController] unhandled state in Update method");
        }
    }

    public void Chase(GameObject target)
    {
        if (motor.RotateTowards(target.transform.position, data.turnSpeed))
        {
            //Do Nothing
        }
        else
        {
            if (Vector3.SqrMagnitude(transform.position - target.transform.position) >= (closeEnough * closeEnough))
            {
                motor.Move(data.moveSpeed);
            }
            else
            {
                shooter.shoot();
            }

        }
    }

    public void Flee(GameObject target)
    {
        //Get Vector to target
        Vector3 vectorToTarget = target.transform.position - transform.position;
        //Get the vector away from the target
        Vector3 vectorAwayFromTarget = -1 * vectorToTarget;
        //Normalize the Vector
        vectorAwayFromTarget.Normalize();
        //Adjust Flee Distance
        vectorAwayFromTarget *= fleeDistance;
        //Set Flee Position
        Vector3 fleePosition = vectorAwayFromTarget + transform.position;
        //Move away from target
        if (motor.RotateTowards(vectorAwayFromTarget.normalized, data.moveSpeed))
        {
            //Do Nothing
        }
        else
        {
            motor.Move(data.moveSpeed);
        }
    }
}
