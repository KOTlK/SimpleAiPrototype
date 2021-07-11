using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceOfficer : Human
{
    private readonly float _searchDistance = 40f;    
    private readonly float _movementSpeed = 8f;
    private readonly EntityType[] _enemies = { EntityType.Villain };


    private void Awake()
    {
        OnAwake();
        Mover = new EntityMover(this, _movementSpeed);
        TargetFinder = new TargetFinder(_enemies, this, _searchDistance);
        Statistics = new DeathStatistic(this);
        Damage = 30;
        StateMachine.Init(Patrol);
    }



    private void Update()
    {
        
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
