using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : Human
{
    private float _movementSpeed = 6f;
    private EntityType[] _targets = { EntityType.PoliceOfficer, EntityType.Hero, EntityType.Citizen };

    private void Start()
    {
        Mover = new EntityMover(this.transform, _movementSpeed);
    }


}
