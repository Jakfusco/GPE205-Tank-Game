using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TankData))] //Required for the script to run
[RequireComponent(typeof(TankMotor))] //Required for the script to run
[RequireComponent(typeof(TankShooter))] //Required for the script to run
[RequireComponent(typeof(Health))] //Required for the script to run
[RequireComponent(typeof(AIController))] //Required for Script to Run
public class FiniteStateMachine : MonoBehaviour
{
    private TankData data; //Tank Data Component
    private TankMotor motor; //Tank Motor Component
    private TankShooter shooter; //Tank Shooter Component
    private Health health; //Tank Health Component
    private AIController controller; // AI Controller Component
    public float fleeDistance = 4.0f;
    public float closeEnough = 4.0f;

    public enum tankPersona { Patrol, Hunter, Coward, Berserker, Sniper };
    public tankPersona Persona = tankPersona.Patrol;

    public enum AIState { Chase, ChaseAndFire, CheckForFlee, Flee, Rest, Patrol, Investigate };
    public AIState State = AIState.Chase;
    private float maxHealth;

    public float stateExitTime;

    private Senses senses;

    public GameObject playerOne;
    public GameObject playerTwo;

    public float lastEventTime;
    public float timerDelay = 10f;
    private float time;

    public float investigateTimer;
    public float investigateTimerDelay;

    // Start is called before the first frame update
    void Start()
    {
        senses = gameObject.GetComponent<Senses>();
        data = GetComponent<TankData>();
        motor = GetComponent<TankMotor>();
        shooter = GetComponent<TankShooter>();
        health = GetComponent<Health>();
        controller = GetComponent<AIController>();

        lastEventTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;


        if (senses.CanSee(playerOne))
        {
            Debug.Log("I see you");
        }
        if (senses.CanHear(playerOne))
        {
            Debug.Log("I hear you. Give me your memes");
        }
        switch (Persona)
        {
            case tankPersona.Patrol:
                {
                    PatrolFSM();
                    break;
                }
            case tankPersona.Hunter:
                {
                    HuntFSM();
                    break;
                }
            case tankPersona.Coward:
                {
                    CowardFSM();
                    break;
                }
            case tankPersona.Berserker:
                {
                    BerserkFSM();
                    break;
                }
            case tankPersona.Sniper:
                {
                    SnipeFSM();
                    break;
                }
            default:
                Debug.LogWarning("[SampleFSM] Unimplemented FSM");
                break;
        }
        switch (State)
        {
            case AIState.Chase:
                DoAdvance(playerOne);
                break;

            case AIState.ChaseAndFire:
                ChaseAndFire(playerOne);
                break;
            case AIState.Rest:
                break;
            case AIState.Patrol:
                controller.Patrol();
                break;
            case AIState.Flee:
                DoFlee(playerOne);
                break;
            case AIState.Investigate:
                motor.RotateTowards(playerOne.transform.position, data.turnSpeed);
                break;
        }

    }

    private void SnipeFSM()
    {
        throw new NotImplementedException();
    }

    private void BerserkFSM()
    {
        throw new NotImplementedException();
    }

    private void CowardFSM()  //Operates like a Patrol Tank, but will run away from the player if they get too close.
    {
        if (playerOne.transform != null)
        {
            if ((Vector3.Distance(playerOne.transform.position, this.transform.position)) <= fleeDistance)
            {
                ChangeState(AIState.Flee);
            }
            else
            {
                ChangeState(AIState.Rest);

            }

        }
    }

    private void HuntFSM() //Hunts the nearest tank down. knows where the player is on spawn.
    {
        if (playerOne.transform != null)
        {
            if ((Vector3.Distance(playerOne.transform.position, this.transform.position)) <= closeEnough)
            {
                ChangeState(AIState.ChaseAndFire);
            }
            else
            {
                ChangeState(AIState.Chase);

            }

        }
    }

    /// <summary>
    /// If the player is dead, or the tank cannot see or hear the player, it will loop its patrol. If not, it will chase the player down and attack them.
    /// </summary>
    
    private void PatrolFSM() 
    {
        if(playerOne.transform != null)
        {
            if (senses.CanSee(playerOne))
            {
                ChangeState(AIState.ChaseAndFire);
            }
            else if (senses.CanHear(playerOne))
            {
                ChangeState(AIState.Investigate);
            }
            else
            {
                ChangeState(AIState.Patrol);
            }
        }
        else
        {
            ChangeState(AIState.Patrol);
        }
    }

    private bool PlayerIsInRange()
    {
        //TODO Write this method
        return true;
    }

    public void ChaseAndFire(GameObject target)
    {
        motor.RotateTowards(target.transform.position, data.turnSpeed);

        if (controller.canMove((data.moveSpeed * 0.5f)))
        {
            motor.Move(data.moveSpeed * 0.5f);
        }
        else
        {
            controller.avoidStage = 1;
        }
        if (time >= lastEventTime + timerDelay)
        {
            lastEventTime = Time.time;
            shooter.shoot();

        }


    }

    void ChangeState(AIState newState)
    {
        State = newState;

        stateExitTime = Time.time;
    }

    public void Chase(GameObject target)
    {
        motor.RotateTowards(target.transform.position, data.turnSpeed);

        if (controller.canMove(data.moveSpeed))
        {
            motor.Move(data.moveSpeed);
        }
        else
        {
            controller.avoidStage = 1;
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
        //Set Flee Position
        Vector3 fleePosition = vectorAwayFromTarget + transform.position;
        //Move away from target
        motor.RotateTowards(fleePosition, data.turnSpeed);

        if (controller.canMove(data.moveSpeed))
        {
            motor.Move(data.moveSpeed * 2.0f);
        }
        else
        {
            controller.avoidStage = 1;
        }

    }

    public void DoAdvance(GameObject target)
    {
        if (controller.avoidStage != 0)
        {
            controller.DoAvoidance();
        }
        else
        {
            Chase(target);
        }
    }
    public void DoFlee(GameObject target)
    {
        if (controller.avoidStage != 0)
        {
            controller.DoAvoidance();
        }
        else
        {
            Flee(target);
        }
    }
}
