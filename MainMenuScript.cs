using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : UnityEngine.MonoBehaviour
{
   
    public void PlayTheGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitTheGame()
    {
        Debug.Log("quit the game");
        Application.Quit();
    }

}
