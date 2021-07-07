using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder
{
    private EntityType[] _enemies;
    private Human _target;
    private Human _entity;
    private float _searchDistance;
    private EntitiesPool Pool => EntitiesPool.Pool;

    public TargetFinder(EntityType[] enemies, Human entity, float searchDistance)
    {
        _enemies = enemies;
        _entity = entity;
        _searchDistance = searchDistance;
    }

    public Human SearchForTarget()
    {
        if (Pool.GetActiveEntities().Count > 0)
        {
            foreach (GameObject i in Pool.GetActiveEntities())
            {
                foreach (EntityType type in _enemies)
                {
                    if (i.TryGetComponent<Human>(out Human enemy) && enemy.Type == type)
                    {
                        var sqrDistanceToEntity = (_entity.transform.position - enemy.transform.position).sqrMagnitude;
                        if (sqrDistanceToEntity <= _searchDistance * _searchDistance)
                        {
                            return enemy;
                        }

                    }
                }
            }
        }
        
        return null;
    }

    public IEnumerator FindTarget(float cooldown)
    {
        while (_entity.CurrentTarget == null)
        {
            _entity.CurrentTarget = SearchForTarget();
            Debug.Log("Looking for target...");
            yield return new WaitForSeconds(cooldown);
        }
    }

}
