using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverMenu;
    public TMP_Text player1Score;
    public TMP_Text player2Score;
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
        player1Score.text = ("Player 1 Score: " + GameManager.Instance.player1Score);
        player2Score.text = ("Player 2 Score: " + GameManager.Instance.player2Score);
        highScore.text = ("High Score: " + GameManager.Instance.highScore);
    }
}
