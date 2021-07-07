using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRenderer : MonoBehaviour
{
    public static GroundRenderer Renderer;
    [SerializeField] private Transform _ground;
    private Renderer _groundRenderer;

    private void Awake()
    {
        _groundRenderer = _ground.GetComponent<Renderer>();
        if (Renderer == null)
        {
            Renderer = this;
        } else
        {
            throw new System.NullReferenceException();
        }

    }

    public Vector3 GetRandomPointOnGround()
    {
        return _groundRenderer.GetRandomPointOnCube();
    }
}
