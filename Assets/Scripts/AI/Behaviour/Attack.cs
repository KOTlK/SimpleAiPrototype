using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    private float _attackDistance = 7f;
    private Coroutine _moving;
    private Coroutine _attacking;
    public Attack(StateMachine stateMachine, Human entity) : base(stateMachine, entity)
    {
        
    }

    public override void Enter()
    {
        Entity.StopAllCoroutines();
        Entity.CurrentTarget.OnEntityDeath += StopAttacking;
        _moving = null;
        _attacking = null;
    }

    public override void Exit()
    {
        Entity.StopAllCoroutines();
        Entity.CurrentTarget.OnEntityDeath -= StopAttacking;
        _moving = null;
        _attacking = null;
    }

    public override void UpdateLogic()
    {
        if (_moving == null)
        {
            _moving = Entity.StartCoroutine(Entity.Mover.MoveTo(Entity.CurrentTarget.transform.position));
        }

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
