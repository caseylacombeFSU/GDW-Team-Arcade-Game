using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject gameWon;

    private int winCon = 0;
    public bool gameComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        gameComplete = true;
    }

    public void GameWon()
    {
        gameWon.gameObject.SetActive(true);
        gameComplete = true;
    }

    public void WinConIncrement()
    {
        winCon++;
    }

    public void WinConDecrement()
    {
        winCon--;
    }

}
