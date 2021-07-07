using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabled : State
{
    public Disabled(StateMachine statemachine, Human entity) : base(statemachine, entity)
    {

    }

    public override void Enter()
    {
        Entity.StopAllCoroutines();
    }

    public override void Exit()
    {
        
    }

    public override void UpdateLogic()
    {
    }
}
