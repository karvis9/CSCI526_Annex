using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI gameResult;
    public static GameOverScreen gm;

    public void Awake()
    {
        Debug.Log("Setting GameOver screen to inactive");
        gm = this;
        gameObject.SetActive(false);

    }

    public void EndGame(int Score, bool PlayerWon)
    {
        Debug.Log("Ending game!");
        gameObject.SetActive(true);
        pointsText.text = Score.ToString() + " points";
        if (PlayerWon)
        {
            gameResult.text = "WINNER!!!";
        } else
        {
            gameResult.text = "OOPS, you lost!!!";
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game!");
        SceneManager.LoadScene("MainScene");
    }
}
