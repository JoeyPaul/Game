using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Variables
    public float moveSpeed = 1f;
    bool minionMoved = false;
    //time
    private float timer = 0.0f;
    public float waitingTime = 2.0f;
    //movement
    Vector2 movement;
    //components
    public Rigidbody2D rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //animator 
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // add and decrease movement.x randomly     
        //Delay the movement so it doesn't happen too quickly
        if (!minionMoved)
        {
            timer += Time.deltaTime;
            DelayAction(2);
            if (timer > waitingTime)
            {
                movement.x = 0;
            }
        }
      
    }

    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    //changes the movement.x variable randomly between -1, 0 and 1
    void randomMovement()
    {
        // add and decrease movement.x randomly
        int randomNum = Random.Range(1, 1000);
        if (randomNum < 51 && movement.x != 1)
        {
            movement.x = 1;
        }
        else if (randomNum < 101 && randomNum >= 51 && movement.x != -1)
        {
            movement.x = -1;
        }
        else
        {
            movement.x = 0;
        }

        minionMoved = false;
    }

    //this function 
    IEnumerator Sleepy(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        randomMovement();
    }

    void DelayAction(float delayTime)
    {
        StartCoroutine(Sleepy(delayTime));
    }
}
