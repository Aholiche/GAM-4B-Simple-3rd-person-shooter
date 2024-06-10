using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    //Couldn't think of a way to implement a state machine without completely building the player controller from the ground up, so here is what I would have done had I started this from scratch

    public bool grounded;
    bool stateComplete;
    float xInput;
    float YInput;
    public enum PlayerState
    {
        Idle, Running, Airborne
    }

    PlayerState state;

    private void Update()
    {
        if (stateComplete)
        {
            SelectState();
        }
        UpdateState();
    }

    void SelectState()
    {
        if (grounded)
        {
            if (xInput == 0)
            {
                state = PlayerStateMachine.Idle;
                StartIdle();
            }
            else if
            {
                state = PlayerStateMachine.Running;
                StartRunning();
            }
            else 
            {
                state = PlayerStateMachine.Airborne;
                StartAirborne();
            }
        }
    }
    void UpdateState()
    {
        switch (this.state)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Running:
                UpdateRunning();
                break;
            case PlayerState.Airborne:
                UpdateAirBorne();
                break;
        }


    }

    void StartIdle()
    {
        //play Idle animation
    }

    void StartRunning()
    {
        //play running animation
    }

    void StartAirborne()
    {
        //play airbourne animation
    }

    void UpdateIdle()
    {
        if(xInput != 0)
        {
            stateComplete = true;
        }
    }

    void UpdateRunning()
    {
        if(!grounded  || xInput == 0)
        {
            stateComplete = true;
        }
    }

    void UpdateAirBorne()
    {
        if(grounded)
        {
            stateComplete = true;
        }
    }
}