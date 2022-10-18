using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI gameResult;
    // Start is called before the first frame update
    void Start()
    {
     int Score = PlayerPrefs.GetInt("Score");
     Debug.Log("Got the score " + Score);
    //  string playerWon = PlayerPrefs.GetString("PlayerWon");
    pointsText.text = Score.ToString() + " points";
    }

    public void PlayAgain()
    {
        Debug.Log("Restarting level!");
        string Scene = PlayerPrefs.GetString("CurrentScene");
        SceneChanger.sc.switchToScene(Scene);
    }

    public void MainMenu() 
    {
        Debug.Log("Loading main menu");
        SceneChanger.sc.switchToScene("FirstScene");
    }
}
