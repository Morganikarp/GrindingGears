using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject firstmain;
    public GameObject firstmainreopen;

    //Quits the Game when the 'Exit' button is pressed on the Main menu
    public void QuitGame() 
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    //Sets the selected menu button to the options menu when options menu is closed
    public void reopenMain()
    {
        //clear Eventsystem Current Selection
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstmainreopen);
    }
}
