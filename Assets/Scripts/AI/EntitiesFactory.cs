using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesFactory
{
    private readonly GameObject _policeOfficer = Resources.Load<GameObject>("Prefabs/Police");
    private readonly GameObject _villain = Resources.Load<GameObject>("Prefabs/Villain");
    private readonly GameObject _hero = Resources.Load<GameObject>("Prefabs/Hero");
    private readonly GameObject _citizen = Resources.Load<GameObject>("Prefabs/Citizen");
    private uint _policeCount;
    private uint _villainCount;
    private uint _citizenCount;
    private uint _heroCount;
    private Transform _parent;

    private Vector3 _startSpawnPoint;
    private EntitiesPool Pool => EntitiesPool.Pool;



    //private List<Vector3> _linesPositions = new List<Vector3>();
    

    public EntitiesFactory(uint[] entitiesCount, Transform parent)
    {
        _policeCount = entitiesCount[0];
        _villainCount = entitiesCount[1];
        _citizenCount = entitiesCount[2];
        _heroCount = entitiesCount[3];
        _parent = parent;
        _startSpawnPoint = parent.position;
    }


    public void Initialize()
    {
        PreCacheEntities(_policeCount, _policeOfficer);
        PreCacheEntities(_villainCount, _villain);
        PreCacheEntities(_heroCount, _hero);
        PreCacheEntities(_citizenCount, _citizen);
    }

    public void SpawnEntity(EntityType type, Vector3 position)
    {
        if (Pool.GetCachedEntities().Count > 0)
        {
            foreach (GameObject i in Pool.GetCachedEntities())
            {
                if (i.TryGetComponent<Human>(out Human entity) && entity.Type == type)
                {
                    Pool.AddActive(i);
                    i.transform.position = position;
                    i.SetActive(true);
                    break;
                }
            }
        }
        
    }

    


    private void PreCacheEntities(uint count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject gameObject = MonoBehaviour.Instantiate(prefab, _startSpawnPoint, Quaternion.identity, _parent);
            gameObject.SetActive(false);
            Pool.AddToCache(gameObject);
        }
    }

    



    /* Debug
    private IEnumerator DrawRandomLines()
    {
        while (true)
        {
            _linesPositions.Add(GetPointOnGround());
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void RenderLines()
    {
        foreach (Vector3 line in _linesPositions)
        {
            Debug.DrawRay(line, Vector3.up * 100, Color.red);
        }
    }
    */

}
