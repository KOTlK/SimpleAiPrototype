using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogic : MonoBehaviour
{
    [Header("0 - Police, 1 - Villain, 2 - Citizen, 3 - Hero")]
    [SerializeField] private uint[] _entitiesCount;
    [SerializeField] private Transform _parent;
    private EntitiesFactory _factory;
    private DebugActions DebugInput => DebugActions.Input;


    private void Start()
    {
        _factory = new EntitiesFactory(_entitiesCount, _parent);
        DebugInput.OnDebugButton1Press += DebugAction1;
        DebugInput.OnDebugButton2Press += DebugAction2;
        _factory.Initialize();
    }


    private void OnDisable()
    {
        DebugInput.OnDebugButton1Press -= DebugAction1;
        DebugInput.OnDebugButton2Press -= DebugAction2;
    }


    private void DebugAction1()
    {
        _factory.SpawnEntity(EntityType.PoliceOfficer, GroundRenderer.Renderer.GetRandomPointOnGround());
        _factory.SpawnEntity(EntityType.Villain, GroundRenderer.Renderer.GetRandomPointOnGround());
    }

    private void DebugAction2()
    {
        if (EntitiesPool.Pool.GetActiveEntities().Count > 0)
        {
            DebugDamageDealer.ApplyDamage(EntitiesPool.Pool.GetActiveEntities()[0].GetComponent<Human>(), 30);
        }
        
    }


}
