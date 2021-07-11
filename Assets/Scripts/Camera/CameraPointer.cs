using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraPointer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _currentHpText;
    [SerializeField] private TextMeshProUGUI _currentTargetText;
    [SerializeField] private TextMeshProUGUI _currentStateText;
    private RaycastHit _hittedObject;


    private void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out _hittedObject, 30);
        if (_hittedObject.collider != null)
        {
            if (_hittedObject.collider.transform.parent != null)
            {
                if (_hittedObject.collider.transform.parent.TryGetComponent<Human>(out Human human))
                {
                    _currentHpText.text = $"Current Hp - {GetHp(human)}";
                    _currentStateText.text = $"Current state - {GetState(human)}";
                    _currentTargetText.text = $"Current target - {GetTargetName(human)}";
                    _name.text = $"Name: {GetName(human)}";
                }
            }
        }
    }

    private string GetName(Human entity)
    {
        if (entity.Name != null && entity.Name != "" && entity.Name != " ")
        {
            return entity.Name;
        }
        else 
        { 
            return "NoName"; 
        }
    }

    private string GetTargetName(Human entity)
    {
        if (entity.CurrentTarget != null)
        {
            return entity.CurrentTarget.Name;
        } else
        {
            return "No target";
        }
    }

    private State GetState(Human entity)
    {
        if (entity.GetCurrentState() != null)
        {
            return entity.GetCurrentState();
        } return null;
    }

    private int GetHp(Human entity)
    {
        return entity.GetCurrentHp();
    }
}
