using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI gameResult;
    public static GameOverScreen gm;

    public bool gameEnded = false;

    public void Awake()
    {
        Debug.Log("Setting GameOver screen to inactive");
        gm = this;
        gameObject.SetActive(false);

    }

    public void EndGame(int Score, bool PlayerWon, string chosenWord)
    {
        Debug.Log("Ending game!");
        gameEnded = true;
        gameObject.SetActive(true);
        pointsText.text = Score.ToString() + " points";

        // Since we are doing a marathon, I comment out the player winning funciton
        /*if (PlayerWon)
        {
            gameResult.text = "YAYYY!!, you correctly guessed the word - " + chosenWord.ToUpper();
            AnalyticsManager.analyticsManager.SendEvent("Level Cleared");
        } else
        {
            gameResult.text = "OOPS!, you couldn't guess the word - " + chosenWord.ToUpper();
            AnalyticsManager.analyticsManager.SendEvent("Level failed");
        }*/

        
        //gameResult.text = "YAYYY!!, you correctly guessed " + chosenWord + " words!";
        AnalyticsManager.analyticsManager.SendEvent("Level Cleared");
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game!");
        SceneManager.LoadScene("MainScene");
    }

    public void LoadFirstScene() 
    {
        Debug.Log("Loading first scene");
        SceneManager.LoadScene("FirstScene");
    }
}
