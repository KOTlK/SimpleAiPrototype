using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToTarget : State
{

    public MovingToTarget(StateMachine stateMachine, Human entity) : base(stateMachine, entity)
    {
    }


    public override void Enter()
    {
        Entity.StopAllCoroutines();
        Entity.StartCoroutine(Entity.Mover.MoveToTarget());
    }

    public override void Exit()
    {
        Entity.StopAllCoroutines();
    }

    public override void UpdateLogic()
    {
        if (Entity.transform.position.DestinationReached(Entity.CurrentTarget.transform.position, 3f))
        {
            StateMachine.ChangeState(Entity.Attack);
        }

        if (Entity.CurrentTarget == null)
        {
            StateMachine.ChangeState(Entity.Patrol);
        }
    }

}
