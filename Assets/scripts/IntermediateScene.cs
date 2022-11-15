using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntermediateScene : MonoBehaviour
{

    // Start is called before the first frame update
    //public Text arrowsLeftT;
    //public Text timeLeftT;
    //pricate Image star1;
    //public GameObject star2;
    //public GameObject star3;
    void Start()
    {
        int prevScore = PlayerPrefs.GetInt("Score");
        int curScore = ScoreManager.sm.getCurrentPoint();
        int total = prevScore + curScore;
        //score.text = "Your score is " + total;
        PlayerPrefs.SetInt("Score", total);
        //StartCoroutine(ChangeText(3));
        int arrowsLeft = ArrowsLeftText.arrowsLeftTextObj.GetUsed();
        int timeLeft = CountDownTimer.countDownTimerObj.getTimeLeft();
        string word = WordBlanks.wb.word;
        if (arrowsLeft <= ((int) 1.5 * word.Length))
        {
            GameObject.Find("star1").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("star2").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("star3").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else if (arrowsLeft <= ((int)2 * word.Length))
        {
            GameObject.Find("star1").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("star2").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("star3").GetComponent<Image>().color = new Color32(56, 56, 56, 255);
        }
        else
        {
            GameObject.Find("star1").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("star2").GetComponent<Image>().color = new Color32(56, 56, 56, 255);
            GameObject.Find("star3").GetComponent<Image>().color = new Color32(56, 56, 56, 255);
        }
        GameObject.Find("arrows").GetComponent<Text>().text = "Arrows Used: " + arrowsLeft.ToString();
        GameObject.Find("time").GetComponent<Text>().text = "Time left: " + timeLeft.ToString();
    }

    IEnumerator ChangeText(int halt)
    {
        yield return new WaitForSeconds(halt);
    }

  public static void Submit()
  {
    SceneChanger.sc.switchToNextLevel();
  }

  public static void ReplaySubmit()
  {
    SceneChanger.sc.replaySameLevel();
  }
}
