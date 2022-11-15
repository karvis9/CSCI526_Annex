using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowsLeftText : MonoBehaviour
{
    public static ArrowsLeftText arrowsLeftTextObj;

    // Start is called before the first frame update
    
    int arrowsLeft = 20;
    int arrowsUsed = 0;
    int hintArrowsLeft;
    public Text arrowsLeftTextt;
    public bool start;


    private ArrowsLeftText ()
    {

    }

    void Start()
    {
        arrowsLeft = 20;
        arrowsUsed = 0;
        hintArrowsLeft = 3;
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
        arrowsLeftTextt.text = arrowsLeft.ToString("0") + "/"  + hintArrowsLeft.ToString("0");

    }

    void updateArrowCnt()
    {
        if (arrowsLeft >= 1)
        {
            arrowsLeftTextt.text = arrowsLeft.ToString("0")  + "/" + hintArrowsLeft.ToString("0");
            if (start == false)
                updateArrowsLeft(arrowsLeft);
            return;
        }
        else
        {
            arrowsLeftTextt.text = "0";
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
        arrowsUsed += num;
        Debug.Log("arrows left " + arrowsLeft);
        Debug.Log("hint left " + hintArrowsLeft);
        if (arrowsLeft <= 0)
        {
            arrowsLeft = 0;
            Debug.Log("No more arrows left");
            string curLevel = SceneChanger.sc.getCurrentScene().name;
            if (ScoreManager.sm.getFinalScore() >= 400) {
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

    public void RemoveHint(int num){
        hintArrowsLeft-=num;
        this.Remove(0);
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
    public int GetUsed()
    {
        return arrowsUsed;
    }
    public int GetHint()
    {
        return hintArrowsLeft;
    }
}
