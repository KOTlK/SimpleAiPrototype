using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateMachine StateMachine;
    protected Human Entity;

    public State (StateMachine stateMachine, Human entity)
    {
        StateMachine = stateMachine;
        Entity = entity;
    }

    public abstract void Enter();
    public abstract void UpdateLogic();
    public abstract void Exit();

    public virtual void OnDisable()
    {

    }
}
