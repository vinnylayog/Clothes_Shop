using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSprite : MonoBehaviour
{
    public SpriteRenderer equipSpriteRenderer;

    void Start()
    {
        equipSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
}
