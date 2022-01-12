using System.Collections;
using System;
using UnityEngine;

public class Simple2DMovement : MonoBehaviour
{
    private bool isMoving;
    private bool isStopped;
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float topSpeed;

    // Use this for initializtion
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    internal void Move(Vector2 direction)
    {
        isMoving = true;
        isStopped = false;
        rigidbody.velocity = new Vector2(direction.x * topSpeed, direction.y * topSpeed);

    }
    private void LateUpdate()
    {
        // If we are not updating movement this frame, then slow us down
        if (!isMoving)
        {
            SlowDown();
        }
        isMoving = false;
    }

    private void SlowDown()
    {
        if (!isStopped)
        {
            rigidbody.velocity = Vector2.zero;
            isStopped = true;
        }
    }
}
