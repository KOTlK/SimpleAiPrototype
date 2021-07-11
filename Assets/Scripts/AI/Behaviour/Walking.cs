using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : State
{
    public Walking(StateMachine stateMachine, Citizen entity) : base(stateMachine, entity)
    {

    }

    public override void Enter()
    {
        Entity.StopAllCoroutines();
        Entity.StartCoroutine(Entity.Mover.Patrol(GroundRenderer.Renderer.GetRandomPointOnGround()));
    }

    public override void Exit()
    {
        Entity.StopAllCoroutines();
    }

    public override void UpdateLogic()
    {
    }


}
