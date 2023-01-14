using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform myTarget;

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float damping;

    private Vector3 velocity = Vector3.zero;

    //Camera follows the player with smooth damping
    private void FixedUpdate()
    {
        Vector3 movePosition = myTarget.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
