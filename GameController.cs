using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //grab the box colliders for the king and the main character
    public BoxCollider2D bcMC;
    public BoxCollider2D bcKing;

    public GameObject gameOverOverlay;
    public GameObject gameWinUI;
    public GameObject goldMedal;
    public GameObject silverMedal;
    public GameObject bronzeMedal;

    public potScript pot;

    //has the game been won
    bool gameWon;

    // Start is called before the first frame update
    void Start()
    {
        gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        //--win condition
        if (bcMC.IsTouching(bcKing))
        {
            gameWon = true;
            //You win the level, 
            Debug.Log("You win");
            if (pot.potVolume >= 9500 && gameWon)
            {
                //You win a gold medal, next level unlocked
                gameWinUI.SetActive(true);
                goldMedal.SetActive(true);
            }
            else if (pot.potVolume >= 7500 && pot.potVolume < 10000 && gameWon)
            {
                //You win a silver medal, next level unlocked
                gameWinUI.SetActive(true);
                silverMedal.SetActive(true);
            }
            else if (pot.potVolume >= 5000 && pot.potVolume < 7500 && gameWon)
            {
                //You win a bronze medal, next level unlocked
                gameWinUI.SetActive(true);
                bronzeMedal.SetActive(true);
            }
            else
                gameWon = false;
        }
        
        if (bcMC.IsTouching(bcKing) && gameWon  == false)
        {
            //No medal. You have to beat this level again to unlock the next level
            gameOverOverlay.SetActive(true);
        }
        //--Lose condition
        if (pot.potVolume <= 0)
        {
            //gameover
            //UI gameover canvas is turned on
            gameOverOverlay.SetActive(true);
        }
    }
}
