using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Specialized;

public class HUD : MonoBehaviour
{
    public Sprite[] charactersprites;
    public GameObject[] characterprefabs;
    public Image P1image;
    public Image P2image;
    public TMP_Text P1name;
    public TMP_Text P2name;
    public TMP_Text rTimer;
    public TMP_Text rNumber;
    public TMP_Text startCountdownText;
    
    private int selectedCharacter;
    private int P2selectedCharacter;
    public static float startingTimer;
    public static float currentTime = 0f;
    private float elapsedTime = 0f;
    private float startedTime = 0f;
    private float startCountdown = 5;
    private float remainingTime = 0;
    private float roundNumber;
    

    // Start is called before the first frame update
    void Start()
    {    
        startingTimer = SettingsMenu.roundTimer;
        currentTime = startingTimer;
        roundNumber = RoundManager.roundsleft;    
        setSprites();
        setnames();
        displayroundNumber();
        startcountdowntimer();
    }

        // Update is called once per frame
    void Update()
    {
        roundStartTimer();
    }

    void startcountdowntimer()
    {
        startedTime = Time.realtimeSinceStartup;
    }

    void roundStartTimer()
    {
        if (remainingTime >= 0)
        {
            Time.timeScale = 0;
            elapsedTime = Time.realtimeSinceStartup - startedTime;
            remainingTime = startCountdown - elapsedTime;
            remainingTime = Mathf.RoundToInt(remainingTime);
            startCountdownText.enabled = true;
            startCountdownText.text = "" + remainingTime;
        }
        else
        {
        Time.timeScale = 1;
        startCountdownText.enabled = false;
        startTimer();
        }
  
    }

    private void displayroundNumber()
    {
        rNumber.text = "Round: " + roundNumber;
    }

    private void startTimer()
    {
        currentTime -= 1 * Time.deltaTime;
        rTimer.text = "Time Left: " + Mathf.Round(currentTime);
    }

    private void setSprites()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        P2selectedCharacter = PlayerPrefs.GetInt("P2selectedCharacter");
        P1image.sprite = charactersprites[selectedCharacter];
        P2image.sprite = charactersprites[P2selectedCharacter];      
    }

    private void setnames()
    {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        P2selectedCharacter = PlayerPrefs.GetInt("P2selectedCharacter");
        P1name.text = "Player 1: " + characterprefabs[selectedCharacter].name;
        P2name.text = "Player 2: " + characterprefabs[P2selectedCharacter].name;      
    }

}
