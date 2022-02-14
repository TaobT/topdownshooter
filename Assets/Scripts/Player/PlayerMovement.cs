using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Physics Reference
    private Rigidbody2D rb;

    //Stats
    private float movementSpeed = 6;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement() => rb.velocity = InputManager.moveVector * movementSpeed;
}
