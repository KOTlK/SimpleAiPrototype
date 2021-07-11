using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    private readonly float _attackDistance = 5f;
    private Coroutine _attacking;
    public Attack(StateMachine stateMachine, Human entity) : base(stateMachine, entity)
    {
        
    }

    public override void Enter()
    {
        Entity.StopAllCoroutines();
        Entity.CurrentTarget.OnEntityDeath += StopAttacking;
        _attacking = null;
    }

    public override void Exit()
    {
        Entity.StopAllCoroutines();
        Entity.CurrentTarget.OnEntityDeath -= StopAttacking;
        _attacking = null;
    }

    public override void UpdateLogic()
    {
        if ((Entity.transform.position - Entity.CurrentTarget.transform.position).sqrMagnitude <= _attackDistance * _attackDistance)
        {
            if (_attacking == null)
            {
                StartAttackingCoroutine();
            }
        }

        if (Entity.CurrentTarget.isDead)
        {
            StopAttacking();
        }

        if (Entity.CurrentTarget != null)
        {
            if (Entity.transform.position.SqrDistanceTo(Entity.CurrentTarget.transform.position) > _attackDistance)
            {
                StateMachine.ChangeState(Entity.MovingToTarget);
            }
        }
    }

    private void StopAttacking()
    {
        StateMachine.ChangeState(Entity.Patrol);
    }

    private void StartAttackingCoroutine()
    {

        _attacking = Entity.StartCoroutine(Entity.AttackTarget(Entity.CurrentTarget));
    }
}
