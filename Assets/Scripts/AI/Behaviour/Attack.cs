using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    public Attack(StateMachine stateMachine, Human entity) : base(stateMachine, entity)
    {

    }

    public override void Enter()
    {
        Entity.StartCoroutine(Entity.Mover.MoveTo(Entity.CurrentTarget.transform.position));
        Debug.Log($"Attacking {Entity.CurrentTarget}");
    }

    public override void Exit()
    {
        Entity.StopAllCoroutines();
    }

    public override void UpdateLogic()
    {
        if (Entity.CurrentTarget.GetCurrentHp() > 0)
        {
            Entity.StartCoroutine(Entity.AttackTarget(5f));
        } else
        {
            StateMachine.ChangeState(Entity.Patrol);
        }
    }
}
