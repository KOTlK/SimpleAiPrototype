using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesPool : MonoBehaviour
{
    public static EntitiesPool Pool;

    private List<GameObject> _cachedEntities = new List<GameObject>();
    private List<GameObject> _activeEntities = new List<GameObject>();

    private void Awake()
    {

        if (Pool == null)
        {
            Pool = this;
        } else
        {
            throw new System.NullReferenceException();
        }
    }


    public void AddToCache(GameObject entity)
    {
        _cachedEntities.Add(entity);
    }

    public void AddActive(GameObject entity)
    {
        _cachedEntities.Remove(entity);
        _activeEntities.Add(entity);
    }

    public void RemoveActive(GameObject entity)
    {
        entity.SetActive(false);
        _activeEntities.Remove(entity);
        _cachedEntities.Add(entity);
        entity.transform.position = new Vector3(9999, 9999, 9999);
    }

    public List<GameObject> GetCachedEntities()
    {
        return _cachedEntities;
    }

    public List<GameObject> GetActiveEntities()
    {
        return _activeEntities;
    }
    public void RemoveFirstActive()
    {
        RemoveActive(_activeEntities[1]);
    }
}
