using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public VariableJoystick joystick;
    public float moveSpeed = 0;

    private Transform thisTransform;
    private Rigidbody rigidbody;
    private Vector3 targetPosition;
    private Vector3 targetRotation;

    private void Start()
    {
        thisTransform = transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer(joystick.Direction);
        RotatePlayer(joystick.Direction);
    }

    void MovePlayer(Vector2 value)
    {
        if (value.x != 0f || value.y != 0f)
            animator.Play("Walk");
        else
            animator.Play("Idle");

        // Set the movement vector based on the axis input.
        targetPosition.Set(value.x, 0f, value.y);
        // Normalise the movement vector and make it proportional to the speed per second.
        targetPosition = Time.deltaTime * moveSpeed * targetPosition.normalized;
        rigidbody.MovePosition(thisTransform.position + targetPosition);
    }

    void RotatePlayer(Vector2 value)
    {
        if (value.x != 0 && value.y != 0)
        {
            targetRotation.y = Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg;
            thisTransform.eulerAngles = targetRotation;
        }
    }
}