using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightMinion : MonoBehaviour
{
    //Variables
    public float moveSpeed = 1f;

    //time
    private float timer = 0.0f;
    public float waitingTime = 1.0f;
    public float delayTime = 4.2f;

    //movement
    Vector2 movement;
    //components
    public Rigidbody2D rb;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        //animator 
        animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        //Delay the movement so it doesn't happen too quickly
        timer += Time.deltaTime;

        if (timer > waitingTime)
            //delay move left
            movement.x = 1;

        //DelayAction(2);
        if (timer > delayTime)
        {
            //delay move right
            movement.x = -1;
            //DelayAction2(2);
            timer = 0.0f;
        }

        //if x position is > 4, teleport to x-5.5
        if (transform.localPosition.x > 4)
        {
            transform.localPosition.Set(-5.5f, 23, 18.13f);
        }
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
}
