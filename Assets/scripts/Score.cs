using UnityEngine.UI;
using UnityEngine;

using TMPro;
using System;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int ActualScore = 0;
    public int DisplayScore = 0;
    public float AdjustingTime = 1.0f;
    void Update()
    {
        ActualScore = ScoreManager.sm.getCurrentPoint();
        if(DisplayScore < ActualScore) {
            DisplayScore++;
            scoreText.color = Color.blue;
        }
        else if(DisplayScore > ActualScore) {
            DisplayScore--;
            scoreText.color = Color.red;
        }
        else {
            scoreText.color = Color.black;
        }
        scoreText.text = DisplayScore.ToString();
        //scoreText.text = ScoreManager.sm.getCurrentPoint().ToString();
    }
}
