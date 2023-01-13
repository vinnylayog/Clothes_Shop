using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSprite : MonoBehaviour
{
    //Sprite for equipment drawn on Player Character
    public SpriteRenderer equipSpriteRenderer;

    void Start()
    {
        equipSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
}
