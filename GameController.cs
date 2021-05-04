using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //grab the box colliders for the king and the main character
    public BoxCollider2D bcMC;
    public BoxCollider2D bcKing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //--win condition
        if (bcMC.IsTouching(bcKing))
        {
            //You win the level, 
            Debug.Log("You win");
        }
    }
}
