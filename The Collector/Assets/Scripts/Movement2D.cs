using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Physics bade 2D movement that expects Gravity
/// Base functionality includes left and right movement as well as jumping
/// And falling
/// When we move we will tell the Animation Controller to update
/// When we jump we will tell the Animation Controller to update
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Movement2D : MonoBehaviour
{
   
    // 2D Rigidbody
    private Rigidbody2D rigidbody;
    [SerializeField]private float speed = 5.0f;

    private bool isOnGround = true;
    private bool isMoving = false;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        // Attach all the references we know about
        rigidbody = GetComponent<Rigidbody2D>();
    }
    internal void Move(Vector2 direction)
    {
        playerDirection = direction;


    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition((Vector2)transform.position + playerDirection * speed * Time.fixedDeltaTime);
    }

}