using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    public Patrol(StateMachine stateMachine, Human entity) : base(stateMachine, entity)
    {

    }

    public override void Enter()
    {
        Entity.ResetTarget();
        Entity.StartCoroutine(Entity.Mover.Patrol(GroundRenderer.Renderer.GetRandomPointOnGround()));
        Entity.StartCoroutine(Entity.TargetFinder.FindTarget(1f));
    }

    public override void Exit()
    {
        Entity.StopCoroutine(Entity.Mover.Patrol(GroundRenderer.Renderer.GetRandomPointOnGround()));
        Entity.StopCoroutine(Entity.TargetFinder.FindTarget(5f));
    }

    public override void UpdateLogic()
    {
        if (Entity.CurrentTarget != null)
        {
            StateMachine.ChangeState(Entity.MovingToTarget);
        }
    }

    public override void OnDisable()
    {
        base.OnDisable();
        Entity.StopAllCoroutines();
    }
}
