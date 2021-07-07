using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMover
{
    private readonly Transform _entity;
    private readonly float _speed;
    private readonly float _nearDistance = 2f;
    private Vector3 _currentDestination;

    public EntityMover(Transform entity, float speed)
    {
        _entity = entity;
        _speed = speed;
        _currentDestination = _entity.transform.position;
    }

    /*public void MoveTo(Vector3 directionPoint)
    {


        if (DestinationReached(_entity, directionPoint) == false)
        {
            _entity.LookAt(directionPoint);
            _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, directionPoint, _speed * Time.deltaTime);
        } 
        
    }*/

    public IEnumerator Patrol(Vector3 startDestinationPoint)
    {
        if (DestinationReached(_entity, _currentDestination))
        {
            _currentDestination = startDestinationPoint;
        }

        while (true)
        {
            if (DestinationReached(_entity, _currentDestination))
            {
                _currentDestination = GroundRenderer.Renderer.GetRandomPointOnGround();
            }
            _entity.LookAt(_currentDestination);
            _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, _currentDestination, _speed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator MoveTo(Vector3 target)
    {
        while (DestinationReached(_entity, target) == false)
        {
            _entity.LookAt(target);
            _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }
    }


    /*public void MoveTo(float x, float y, float z)
    {

        Vector3 direction = new Vector3(x, y, z);

        if (DestinationReached(_entity, direction) == false)
        {
            _currentDestination = direction;

            _entity.LookAt(_currentDestination);
            _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, _currentDestination, _speed * Time.deltaTime);
        }


    }*/

    

    private bool DestinationReached(Transform entity, Vector3 target)
    {
        float sqrDistance = (entity.transform.position - target).sqrMagnitude;
        if (sqrDistance <= _nearDistance * _nearDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
