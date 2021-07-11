using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : Human
{
    private float _movementSpeed = 4f;

    private void Awake()
    {
        OnAwake();
        Damage = 0;
        Walking = new Walking(StateMachine, this);
        Mover = new EntityMover(this, _movementSpeed);
        Statistics = new DeathStatistic(this);
        StateMachine.Init(Walking);
    }

    private void OnEnable()
    {
        BaseOnEnable();
        StateMachine.ChangeState(Walking);
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
