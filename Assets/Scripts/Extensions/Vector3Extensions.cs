using System.Collections;
using UnityEngine;

public static class Vector3Extensions
{
    public static bool DestinationReached(this Vector3 entityPosition, Vector3 destination, float nearDistance)
    {
        if ((entityPosition - destination).sqrMagnitude <= nearDistance * nearDistance)
        {
            return true;
        }else
        {
            return false;
        }
    }

    public static float SqrDistanceTo(this Vector3 self, Vector3 target)
    {
        return (self - target).sqrMagnitude;
    }
}