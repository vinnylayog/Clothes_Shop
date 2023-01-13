using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteYAligner : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Adjusts the Z position / Order in Layer based on it's Y position
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - (mySpriteRenderer.bounds.size.y/2));
    }
}
