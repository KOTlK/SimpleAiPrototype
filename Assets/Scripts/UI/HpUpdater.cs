using TMPro;
using UnityEngine;

public class HpUpdater
{
    private Camera _camera => FlyingCamera.Camera;
    private Human _entity;
    private TextMeshPro _text;

    public HpUpdater(Human entity, TextMeshPro text)
    {
        _entity = entity;
        _text = text;
    }

    public void UpdateRotation()
    {
        RotateHp();
    }


    public void UpdateHp()
    {
        _text.text = $"Hp - {_entity.GetCurrentHp()}";
    }

    private void RotateHp()
    {
        _text.transform.rotation = Quaternion.LookRotation(_text.transform.position - _camera.transform.position);
    }
}
