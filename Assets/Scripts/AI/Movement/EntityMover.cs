using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMover
{
    private readonly Human _entity;
    private readonly float _speed;
    private readonly float _nearDistance = 2f;
    private Vector3 _currentDestination;

    public EntityMover(Human entity, float speed)
    {
        _entity = entity;
        _speed = speed;
        _currentDestination = _entity.transform.position;
    }


    public IEnumerator Patrol(Vector3 startDestinationPoint)
    {
        if (_entity.transform.position.DestinationReached(_currentDestination, _nearDistance))
        {
            _currentDestination = startDestinationPoint;
        }

        while (true)
        {
            if (_entity.transform.position.DestinationReached(_currentDestination, _nearDistance))
            {
                _currentDestination = GroundRenderer.Renderer.GetRandomPointOnGround();
            }
            _entity.transform.LookAt(_currentDestination);
            _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, _currentDestination, _speed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator MoveTo(Vector3 target)
    {

        while (_entity.transform.position.DestinationReached(target, _nearDistance) == false)
        {
            _entity.transform.rotation = Quaternion.RotateTowards(_entity.transform.rotation, Quaternion.Euler(target), _speed * Time.deltaTime);
            _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }
    }

    public IEnumerator MoveToTarget()
    {
        Vector3 target = _entity.CurrentTarget.transform.position;
        while (_entity.transform.position.DestinationReached(target, _nearDistance) == false)
        {
            target = _entity.CurrentTarget.transform.position;
            _entity.transform.LookAt(target);
            _entity.transform.position += _entity.transform.forward * _speed * Time.deltaTime; 
            yield return null;
        }
    }





}
