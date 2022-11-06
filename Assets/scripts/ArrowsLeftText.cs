using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowsLeftText : MonoBehaviour
{
    public static ArrowsLeftText arrowsLeftTextObj;

    // Start is called before the first frame update
    
    int arrowsLeft = 20;
    public Text arrowsLeftTextt;
    public bool start;


    private ArrowsLeftText ()
    {

    }

    void Start()
    {
        arrowsLeft = 20;
        arrowsLeftTextObj = this;
        start = true;
        updateArrowCnt();
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void updateArrowsLeft(int arrows)
    {
        arrowsLeft = arrows;
        arrowsLeftTextt.text = "Arrows Left: " + arrowsLeft.ToString ("0");

    }

    void updateArrowCnt()
    {
        if (arrowsLeft >= 1)
        {
            arrowsLeftTextt.text = "Arrows Left: " + arrowsLeft.ToString("0");
            if (start == false)
                updateArrowsLeft(arrowsLeft);
            return;
        }
        else
        {
            arrowsLeftTextt.text = "Arrows Left: 0";
        }
    }

    public void Add(int num)
    {
        arrowsLeft += num;
        updateArrowCnt();
    }

    public void Remove(int num)
    {
        arrowsLeft -= num;
        Debug.Log("arrows left " + arrowsLeft);
        if (arrowsLeft <= 0)
        {
            arrowsLeft = 0;
            Debug.Log("No more arrows left");
            string curLevel = SceneChanger.sc.getCurrentScene().name;
            if (curLevel == "Level_0")
            {
                // SceneChanger.sc.switchToScene("Level_1");
                SceneChanger.sc.switchToNextLevel();
            }
            else if (curLevel == "Level_1" && ScoreManager.sm.getFinalScore() >= 1000)
            {
                SceneChanger.sc.switchToNextLevel();
                // Scene scene = SceneChanger.sc.getCurrentScene();
                // string level = scene.name.Split("_")[1];
                // if (level == "2"){
                //     GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
                // } else {
                //     // Change this to call loadNextLevel or something
                // SceneChanger.sc.switchToScene("Level_2");
                // }
            }
            else if (curLevel == "Level_2" && ScoreManager.sm.getFinalScore() >= 2000)
            {
                SceneChanger.sc.switchToNextLevel();
            }
            else if (curLevel == "Level_3" && ScoreManager.sm.getFinalScore() >= 3000)
            {
                SceneChanger.sc.switchToNextLevel();
            }
            else if (curLevel == "Level_4" && ScoreManager.sm.getFinalScore() >= 4000)
            {
                SceneChanger.sc.switchToNextLevel();
            }
            else
            {
                AnalyticsManager.analyticsManager.SendEvent("Level failed");
                GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
            }
        }
        updateArrowCnt();
    }

    public void Set(int num)
    {
        arrowsLeft = num;
        if (arrowsLeft < 0)
        {
            arrowsLeft = 0;
        }
        updateArrowCnt();
    }

    public int Get()
    {
        return arrowsLeft;
    }
}
