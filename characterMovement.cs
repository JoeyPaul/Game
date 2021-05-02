using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class characterMovement : UnityEngine.MonoBehaviour
{
	public float moveSpeed = 2f;

	public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    //references:
    //Brackeys: TOP DOWN MOVEMENT in Unity!, YouTube Tutorial
    //https://www.youtube.com/watch?v=whzomFgjT50 
}