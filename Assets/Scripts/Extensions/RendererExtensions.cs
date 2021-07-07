using UnityEngine;

public static class RendererExtensions
{
    public static Vector3 GetRandomPointOnCube(this Renderer renderer)
    {
        Vector3 max = renderer.bounds.max;
        Vector3 min = renderer.bounds.min;

        //Vector3 leftUpPosition = new Vector3(min.x, max.y, max.z);
        //Vector3 rightUpPosition = new Vector3(max.x, max.y, min.z);

        float randomX = Random.Range(min.x + 1, max.x - 1); // +-1 to exclude the situation when entity spawns too close to border
        float randomZ = Random.Range(max.z - 1, min.z + 1);

        return new Vector3(randomX, max.y + 1, randomZ);
    }
}
