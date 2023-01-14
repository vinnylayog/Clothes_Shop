using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    float count = 0.0f;
    public float resetTime = 360.0f;
    public Vector3 resetPosition;

    private void Start()
    {
        resetPosition = transform.position;
    }

    void Update()
    {
        count += 1.0f * Time.deltaTime;

        transform.position += new Vector3(1.0f, 1.0f, 0.0f) * moveSpeed * Time.deltaTime;

        if (count > resetTime)
        {
            count = 0.0f;
            transform.position = resetPosition;
        }
    }
}
