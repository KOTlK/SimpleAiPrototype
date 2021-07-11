using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHolder : MonoBehaviour
{
    public static TextHolder Text;
    [SerializeField] private TextMeshProUGUI _police;
    [SerializeField] private TextMeshProUGUI _villain;
    [SerializeField] private TextMeshProUGUI _hero;
    [SerializeField] private TextMeshProUGUI _citizen;
    private Dictionary<EntityType, TextMeshProUGUI> _keyValuePairs = new Dictionary<EntityType, TextMeshProUGUI>(4);

    private void Awake()
    {
        if (Text == null)
        {
            Text = this;
        } else
        {
            throw new System.NullReferenceException();
        }

        _keyValuePairs.Add(EntityType.PoliceOfficer, _police);
        _keyValuePairs.Add(EntityType.Villain, _villain);
        _keyValuePairs.Add(EntityType.Hero, _hero);
        _keyValuePairs.Add(EntityType.Citizen, _citizen);
    }

    public TextMeshProUGUI GetUIObjectByType(EntityType type)
    {
        return _keyValuePairs[type];
    }


    

}
