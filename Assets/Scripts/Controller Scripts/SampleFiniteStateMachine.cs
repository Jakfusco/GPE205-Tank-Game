using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFiniteStateMachine : MonoBehaviour
{
    public enum tankPersona { Patrol, Hunter, Coward, Berserker, Sniper };
    public tankPersona Persona = tankPersona.Patrol;

    public enum AIState { Chase, ChaseAndFire, CheckForFlee, Flee, Rest};
    public AIState State = AIState.Chase;
    private float health;
    private float maxHealth;

    public float stateExitTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void SnipeFSM()
    {
        throw new NotImplementedException();
    }

    private void BerserkFSM()
    {
        throw new NotImplementedException();
    }

    private void CowardFSM()
    {
        throw new NotImplementedException();
    }

    private void HuntFSM()
    {
        throw new NotImplementedException();
    }

    private void PatrolFSM()
    {
        switch (State)
        {
            case AIState.Chase:
                if (health < maxHealth * 0.5)
                {
                    ChangeState(AIState.CheckForFlee);
                }
                else if (PlayerIsInRange())
                {

                }
                break;
            case AIState.ChaseAndFire:
                ChaseAndFire();
                if (health < maxHealth * 0.5)
                {
                    ChangeState(AIState.CheckForFlee);
                }
                else if (!PlayerIsInRange())
                {
                    ChangeState(AIState.Chase);
                }

                break;
            case AIState.CheckForFlee:
                break;
            case AIState.Flee:
                break;
            case AIState.Rest:
                break;
            default:
                Debug.LogWarning("[SampleFSM] does not exist");
                break;

        }
    }

    private bool PlayerIsInRange()
    {
        //TODO Write this method
        return true;
    }

    private void ChaseAndFire()
    {
        throw new NotImplementedException();
    }

    void ChangeState(AIState newState)
    {
        State = newState;

        stateExitTime = Time.time;
    }


}
