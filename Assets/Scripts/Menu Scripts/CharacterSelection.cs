using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] P1Characters;
    public GameObject[] P2Characters;
    public GameObject[] P1cIcons;
    public GameObject[] P2cIcons;
    public Vector3[] P1SelectPositions; //Make an array to store locations of character icons so we can place a border around them to show current character.
    public Vector3[] P2SelectPositions;
    public GameObject P1CBorder;
    public GameObject P2CBorder;
    public GameObject firstcharacteroption;

    

    public int selectedCharacter = 0;
    public int P2selectedCharacter = 0;
    bool player1Ready = false;
    bool player2Ready = false;


    void Start() 
    {
        P1SelectPositions = new Vector3[P1cIcons.Length];
        P2SelectPositions = new Vector3[P2cIcons.Length];
        
        changeborderPosition();
    }

    private void changeborderPosition()
    {
        for (int i=0; i<P1cIcons.Length;i++)
        {
            P1SelectPositions[i] = P1cIcons[i].transform.position;       
        }
        for (int i=0; i<P2cIcons.Length;i++)
        {   
            P2SelectPositions[i] = P2cIcons[i].transform.position;   
        }
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            NextCharacter();
        }
    }

    public void setfirstoption()
    {
        //clear Eventsystem Current Selection
         EventSystem.current.SetSelectedGameObject(null);
        //Set new selected option
        EventSystem.current.SetSelectedGameObject(firstcharacteroption);
    }

    public void NextCharacter()
    {
        P1Characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % P1Characters.Length;
        P1Characters[selectedCharacter].SetActive(true);
        P1CBorder.transform.position = P1SelectPositions[selectedCharacter];
    }

    public void PrevCharacter()
    {
        P1Characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += P1Characters.Length;
        }
        P1Characters[selectedCharacter].SetActive(true);
        P1CBorder.transform.position = P1SelectPositions[selectedCharacter];
    }
    
    public void P2NextCharacter()
    {
        P2Characters[P2selectedCharacter].SetActive(false);
        P2selectedCharacter = (P2selectedCharacter + 1) % P2Characters.Length;
        P2Characters[P2selectedCharacter].SetActive(true);
        P2CBorder.transform.position = P2SelectPositions[P2selectedCharacter];
    }

    public void P2PrevCharacter()
    {
        P2Characters[P2selectedCharacter].SetActive(false);
        P2selectedCharacter--;
        if (P2selectedCharacter < 0)
        {
            P2selectedCharacter += P2Characters.Length;
        }
        P2Characters[P2selectedCharacter].SetActive(true);
        P2CBorder.transform.position = P2SelectPositions[P2selectedCharacter];
    }

    public void P1CharacterSelect()     //Maybe combine into one
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        player1Ready = true;
        StartGame();

    }

    public void P2CharacterSelect()
    {
        PlayerPrefs.SetInt("P2selectedCharacter", P2selectedCharacter);
        player2Ready = true;
        StartGame();
    }

    public void StartGame()
    {
        if (player2Ready == true && player1Ready == true)
        {
            SceneManager.LoadScene(1);
        }
        else 
        {
            return;
        }
    }


}
