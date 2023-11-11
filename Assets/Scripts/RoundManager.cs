using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoundManager : MonoBehaviour
{

    private GameObject P1;
    private GameObject P2;
    public GameObject winPanel;
    private LoadCharacter Lc;
    private Transform P1spawnPoint;
    private Transform P2spawnPoint;
    public TMP_Text winnerText;
    
    private bool isTimerDone = false;
    private bool p1win = false;
    private bool p2win = false;
    private float startTimer;
    private float currentTimer;
    public static float roundsleft = 3;
    private int p1Score;
    private int p2Score;

    void Start()
    {
        p1Score = PlayerPrefs.GetInt("player1Score"); //assigns p1 and p2 score when the scene is restarted
        p2Score = PlayerPrefs.GetInt("player2Score");
        currentTimer = HUD.currentTime; //calls 
        startTimer = HUD.startingTimer;   
        if (roundsleft < 3)  //Reset's rounds left when reloading the scene with a number below zero
        {
            if (PlayerPrefs.GetFloat("roundNumber") < 0)
            {
                roundsleft = 3f;
            }
            else
            {
                roundsleft = PlayerPrefs.GetFloat("roundNumber");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HUD.currentTime <= 0)
        {
            isTimerDone = true;
        }

        if (isTimerDone || p1win || p2win)
        {
            nextRound();
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
        case "P1":
        p2win = true;
        Debug.Log("p2 win round " + p2win);
        break;
        case "P2":
        p1win = true;
        Debug.Log("p1 win round" + p1win);
        break;
        }
    }

    private void nextRound()
    {
        if (isTimerDone)
        {
            roundsleft -= 1;
            PlayerPrefs.SetFloat("roundNumber", roundsleft);
            isTimerDone = false;
            if (roundsleft < 1)
            {
                winScreen();
            }
            else
            {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            }
            
        }
        else if (p1win)
        {
            PlayerPrefs.SetInt("player1Score", p1Score + 1);
            Debug.Log("P1 score" + PlayerPrefs.GetInt("player1Score"));
            p1win = false;
            roundsleft -= 1;
            PlayerPrefs.SetFloat("roundNumber", roundsleft);
            if (roundsleft < 1)
            {
                winScreen();
            }
            else
            {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            }
        }
        else if (p2win)
        {
            PlayerPrefs.SetInt("player2Score", p2Score + 1);
            Debug.Log("P2 score" + PlayerPrefs.GetInt("player2Score"));
            p1win = false;
            roundsleft -= 1;
            PlayerPrefs.SetFloat("roundNumber", roundsleft);
            if (roundsleft < 1)
            {
                winScreen();
            }
            else
            {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            }
        }
    }

    private void winScreen()
    {
        Debug.Log("win?");
        if(p1Score >  p2Score)
        {
            Time.timeScale = 0;
            Debug.Log("Player 1 wins!!");
            PlayerPrefs.DeleteKey("player1Score");
            PlayerPrefs.DeleteKey("player2Score");
            PlayerPrefs.SetFloat("roundNumber", 3);
            winPanel.SetActive(true);
            winnerText.text = "Player 1 is the Winner!";
        }
        else if (p2Score> p1Score)
        {
            Time.timeScale = 0;
            Debug.Log("Player 2 wins!!");
            PlayerPrefs.DeleteKey("player1Score");
            PlayerPrefs.DeleteKey("player2Score");
            PlayerPrefs.SetFloat("roundNumber", 3);
            winPanel.SetActive(true);
            winnerText.text = "Player 2 is the Winner!";
        }
        else if(p1Score == p2Score)
        {
            Time.timeScale = 0;
            Debug.Log("It's a tie!");
            PlayerPrefs.DeleteKey("player1Score");
            PlayerPrefs.DeleteKey("player2Score");
            PlayerPrefs.SetFloat("roundNumber", 3);
            winPanel.SetActive(true);
            winnerText.text = "It's a tie";
        }

    }
}
