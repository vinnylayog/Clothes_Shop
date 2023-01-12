using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSprite : MonoBehaviour
{
    public SpriteRenderer equipSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        equipSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
