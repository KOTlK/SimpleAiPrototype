using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState;

    public void Init(State startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(State newState)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }
        
        CurrentState = newState;
        CurrentState.Enter();
    }
}
