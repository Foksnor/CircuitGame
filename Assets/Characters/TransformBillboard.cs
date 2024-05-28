using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToBillboard : MonoBehaviour
{
    [SerializeField] Transform Transform = null;

    void Awake()
    {
        Transform.eulerAngles = GlobalSettings.SpriteBillboardVector;
        Transform.position += GlobalSettings.SpriteOffsetVector;
    }
}