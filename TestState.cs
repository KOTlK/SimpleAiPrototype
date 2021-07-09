using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TestState<Machine, Shit> : State
    where Machine : StateMachine
    where Shit : IAgressive
{
    protected StateMachine StateMachine;
    protected Human Entity;

}

