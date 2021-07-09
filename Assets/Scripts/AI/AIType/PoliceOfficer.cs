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
        OnAwake();
        Mover = new EntityMover(this.transform, _movementSpeed);
        TargetFinder = new TargetFinder(_enemies, this, _searchDistance);
        Damage = 30;
        StateMachine.Init(Patrol);
    }



    private void Update()
    {
        if (StateMachine.CurrentState != null)
        {
            StateMachine.CurrentState.UpdateLogic();
        }
        BaseUpdate();
        
    }


    private void OnEnable()
    {
        BaseOnEnable();
        StateMachine.ChangeState(Patrol);
    }

    private void OnDisable()
    {
        BaseOnDisable();
        StateMachine.ChangeState(Disabled);
    }

}
