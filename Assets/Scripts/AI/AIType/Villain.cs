using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : Human
{
    private float _movementSpeed = 6f;
    private float _searchDistance = 40;
    private EntityType[] _enemies = { EntityType.PoliceOfficer, EntityType.Hero, EntityType.Citizen };

    private void Awake()
    {
        OnAwake();
        Mover = new EntityMover(this.transform, _movementSpeed);
        TargetFinder = new TargetFinder(_enemies, this, _searchDistance);
        
    }

    private void OnEnable()
    {
        BaseOnEnable();

    }

    private void OnDisable()
    {
        BaseOnDisable();
    }

    

}
