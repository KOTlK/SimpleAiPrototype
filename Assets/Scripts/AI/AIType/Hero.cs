using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Human
{
    private float _movementSpeed = 9f;
    private float _searchDistance = 50;
    private EntityType[] _enemies = {EntityType.Villain};

    private void Awake()
    {
        OnAwake();
        Damage = 55;
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
