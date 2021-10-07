using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public void Setup(int score) {
        //score = GetComponent<Text> ();
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
    }

    public void RetryButton() {
        Time.timeScale = 1f;
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("GameState");
    }

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game Exited");
    }
}
