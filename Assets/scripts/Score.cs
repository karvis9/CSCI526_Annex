using UnityEngine.UI;
using UnityEngine;

using TMPro;
using System;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = ScoreManager.sm.getCurrentPoint().ToString();
    }
}
