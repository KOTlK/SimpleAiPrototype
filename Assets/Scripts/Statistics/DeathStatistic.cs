using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathStatistic
{
    private Human _entity;
    private readonly TextMeshProUGUI _police;
    private readonly TextMeshProUGUI _villain;
    private readonly TextMeshProUGUI _hero;
    private readonly TextMeshProUGUI _civil;
    private static int s_policeDeaths = 0;
    private static int s_villainDeaths = 0;
    private static int s_heroDeaths = 0;
    private static int s_civilDeaths = 0;
    
    public DeathStatistic(Human entity)
    {
        _entity = entity;
        _police = TextHolder.Text.GetUIObjectByType(EntityType.PoliceOfficer);
        _villain = TextHolder.Text.GetUIObjectByType(EntityType.Villain);
        _hero = TextHolder.Text.GetUIObjectByType(EntityType.Hero);
        _civil = TextHolder.Text.GetUIObjectByType(EntityType.Citizen);
    }

    public void OnEnable()
    {
        _entity.OnDeath += UpdateCounter;
    }

    public void OnDisable()
    {
        _entity.OnDeath -= UpdateCounter;
    }

    private void UpdateCounter(Human sender)
    {
        UpdateScores(sender);
        _police.text = $"Police - {s_policeDeaths}";
        _villain.text = $"Villain - {s_villainDeaths}";
        _hero.text = $"Hero - {s_heroDeaths}";
        _civil.text = $"Citizen - {s_civilDeaths}";
    }



    // )))000)))))0))))))
    private void UpdateScores(Human entity)
    {
        if (entity.Type == EntityType.PoliceOfficer)
        {
            s_policeDeaths++;
        } else if (entity.Type == EntityType.Villain)
        {
            s_villainDeaths++;
        } else if (entity.Type == EntityType.Hero)
        {
            s_heroDeaths++;
        } else if (entity.Type == EntityType.Citizen)
        {
            s_civilDeaths++;
        }
    }
    
}
