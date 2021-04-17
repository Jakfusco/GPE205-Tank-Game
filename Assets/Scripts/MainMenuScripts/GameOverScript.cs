using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverMenu;
    public TMP_Text yourScore;
    public TMP_Text highScore;
    public void OnQuitClicked()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OnRestartClicked()
    {

        SceneManager.LoadScene(2);

    }


    public void OnMenuClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void Start()
    {
        yourScore.text = ("Your Score: " + GameManager.Instance.playerScore.ToString());
        highScore.text = ("High Score: " + GameManager.Instance.highScore.ToString());
    }
}
