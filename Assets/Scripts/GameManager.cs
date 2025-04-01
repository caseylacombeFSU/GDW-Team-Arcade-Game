using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Panel game objects for each game end condition 
    public GameObject gameOver;
    public GameObject gameWon;

    //Int to track how many of the final wincon buttons are currently being stepped on
    private int winCon = 0;
    //bool to track if the game is won, this is used for the PlayerController script 
    public bool gameComplete = false;

    // Update is called once per frame
    // Checks if the enter key is hit to start the game
    // Checks if the win condition is reached to stop the game
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }

        if (winCon == 2)
        {
            GameWon();
        }
    }

    // Game over method
    // Sets gameComplete to true for the PlayerController script and sets the gameOver panel as active
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        gameComplete = true;
    }
    
    // Game won method
    // Sets gameComplete to true for the PlayerController script and sets the gameWon panel as active
    public void GameWon()
    {
        gameWon.gameObject.SetActive(true);
        gameComplete = true;
    }

    // Increments the winCon int
    public void WinConIncrement()
    {
        winCon++;
    }

    // Decrements the winCon int
    public void WinConDecrement()
    {
        winCon--;
    }

}
