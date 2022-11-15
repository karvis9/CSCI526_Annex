using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntermediateScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
     int prevScore = PlayerPrefs.GetInt("Score");
     int curScore = ScoreManager.sm.getCurrentPoint();
     int total = prevScore + curScore;
     //score.text = "Your score is " + total;
     PlayerPrefs.SetInt("Score", total);
     StartCoroutine(ChangeText(3));
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
