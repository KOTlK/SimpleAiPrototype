using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDamageDealer : MonoBehaviour
{
    public static void ApplyDamage(Human entity, int damage)
    {
        entity.ApplyDamage(damage);
    }
}
