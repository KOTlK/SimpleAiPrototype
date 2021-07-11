using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : Human
{
    private float _movementSpeed = 6f;
    private float _searchDistance = 30f;
    private EntityType[] _enemies = { EntityType.PoliceOfficer, EntityType.Hero, EntityType.Citizen };

    private void Awake()
    {
        OnAwake();
        Damage = 20;
        Mover = new EntityMover(this, _movementSpeed);
        TargetFinder = new TargetFinder(_enemies, this, _searchDistance);
        Statistics = new DeathStatistic(this);
        StateMachine.Init(Patrol);
    }

    private void OnEnable()
    {
        BaseOnEnable();
        StateMachine.ChangeState(Patrol);

    }

    private void Update()
    {
        BaseUpdate();
    }

    private void OnDisable()
    {
        BaseOnDisable();
        StateMachine.ChangeState(Disabled);
    }

    

}
