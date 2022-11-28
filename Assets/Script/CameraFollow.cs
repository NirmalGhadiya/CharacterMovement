using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;

    private Vector3 followOffset;
    private Transform thisTransform;

    void Start()
    {
        thisTransform = transform;
        followOffset = thisTransform.position - targetPlayer.position;
    }

    void Update()
    {
        thisTransform.position = targetPlayer.position + followOffset;
    }
}