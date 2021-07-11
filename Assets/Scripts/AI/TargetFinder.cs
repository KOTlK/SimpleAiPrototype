using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder
{
    private EntityType[] _enemies;
    private Human _entity;
    private float _searchDistance;
    private int _chanceToHitCivillian = 10; // 10%
    private EntitiesPool Pool => EntitiesPool.Pool;

    public TargetFinder(EntityType[] enemies, Human entity, float searchDistance)
    {
        _enemies = enemies;
        _entity = entity;
        _searchDistance = searchDistance;
    }

    //)))))))000))))00))))))00))
    public Human SearchForTarget()
    {
        var random = Random.Range(0, 100);
        if (_entity.Type == EntityType.Hero && random >= 100 - _chanceToHitCivillian)
        {
            foreach (GameObject i in Pool.GetActiveEntities())
            {
                if (i.TryGetComponent<Human>(out Human enemy) && enemy.Type == EntityType.Citizen)
                {
                    var sqrDistanceToEntity = _entity.transform.position.SqrDistanceTo(enemy.transform.position);
                    if (sqrDistanceToEntity <= _searchDistance * _searchDistance)
                    {
                        return enemy;
                    }

                }
            }
        }

        if (Pool.GetActiveEntities().Count > 0)
        {
            foreach (GameObject i in Pool.GetActiveEntities())
            {
                foreach (EntityType type in _enemies)
                {
                    if (i.TryGetComponent<Human>(out Human enemy) && enemy.Type == type)
                    {
                        var sqrDistanceToEntity = _entity.transform.position.SqrDistanceTo(enemy.transform.position);
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
            yield return new WaitForSeconds(cooldown);
        }
    }

}
