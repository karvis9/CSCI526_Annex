using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public static CountDownTimer countDownTimerObj;

    // Start is called before the first frame update
    static float curTime;
    float startingTime = 120f;
    public Text CountDownText;

    private CountDownTimer ()
    {

    }

    void Start()
    {
        curTime = startingTime;
        countDownTimerObj = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOverScreen.gm.gameEnded) {
            curTime -= (1 * Time.deltaTime);
            if (curTime <= 0)
                GameOverScreen.gm.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
            CountDownText.text = "Time Left: " + curTime.ToString ("0") + " Secs";
        }
    }

    public void updateTime()
    {
        Debug.Log("before time is " + curTime);
        curTime += 5;
        Debug.Log("current time is "+ curTime);

    }

    public void reduceTime(int time)
    {
        Debug.Log("before time is " + curTime);
        curTime -= time;
        Debug.Log("current time is " + curTime);
    }

    public int getTimeLeft()
    {
        if (curTime > 0)
            return (int) curTime;

        return 0;
        
    }
}
