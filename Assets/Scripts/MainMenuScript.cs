using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    //public GameObject menu;
    //public GameObject GameLoad;
    public void ExitButton() 
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }

    public void StartGame()
    {
        //HideMenu();
        SceneManager.LoadScene("GameState");
    }
}
