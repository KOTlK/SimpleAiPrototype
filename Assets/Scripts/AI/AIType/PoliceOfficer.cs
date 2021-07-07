using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficer : Human
{
    private float _searchDistance = 30f;    
    private readonly float _movementSpeed = 5f;
    private readonly EntityType[] _enemies = { EntityType.Villain };



    private void Awake()
    {
        Mover = new EntityMover(this.transform, _movementSpeed);
        StateMachine = new StateMachine();
        HpUpdater = new HpUpdater(this, TextHP);

        Patrol = new Patrol(StateMachine, this);
        Disabled = new Disabled(StateMachine, this);
        Attack = new Attack(StateMachine, this);

        TargetFinder = new TargetFinder(_enemies, this, _searchDistance);
        CurrentHp = MaxHp;
        StateMachine.Init(Patrol);
    }


    private void Update()
    {
        if (StateMachine.CurrentState != null)
        {
            StateMachine.CurrentState.UpdateLogic();
        }
        HpUpdater.OnUpdate();
        
    }


    private void OnEnable()
    {
        isDead = false;
        StateMachine.ChangeState(Patrol);
        CurrentHp = MaxHp;
        OnHPUpdate += HpUpdater.UpdateHp;
    }

    private void OnDisable()
    {
        StateMachine.ChangeState(Disabled);
        OnHPUpdate -= HpUpdater.UpdateHp;
    }

}
