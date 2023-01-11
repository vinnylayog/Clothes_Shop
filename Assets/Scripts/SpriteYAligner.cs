using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteYAligner : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - (mySpriteRenderer.bounds.size.y/2));
    }
}
