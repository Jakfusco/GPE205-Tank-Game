using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public void OnQuitClicked()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void OnOptionsClicked()
    {
        
    }
}
