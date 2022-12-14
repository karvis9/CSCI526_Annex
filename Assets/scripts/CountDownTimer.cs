using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDownTimer : MonoBehaviour
{
    public static CountDownTimer countDownTimerObj;

    // Start is called before the first frame update
    static float curTime;
    public float startingTime = 120f;
    public Text CountDownText;

    private CountDownTimer ()
    {

    }

    void Start()
    {
        Debug.Log("text"+SceneChanger.sc.getCurrentScene());
        curTime = startingTime;
        
        countDownTimerObj = this;
    }

    // Update is called once per frame
    void Update()
    {
        // if (!GameOverScreen.gm.gameEnded) {
            curTime -= (1 * Time.deltaTime);
            if (curTime <= 0){
                Debug.Log("MAcha " + ScoreManager.sm.getFinalScore());
                if (ScoreManager.sm.getFinalScore() >= 400) {
                    Debug.Log("Points crossed 400");
                    //SceneChanger.sc.switchToNextLevel();
                    // Scene scene = SceneChanger.sc.getCurrentScene();
                    // string level = scene.name.Split("_")[1];
                    // if (level == "2"){
                    //     GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
                    // } else {
                    //     // Change this to call loadNextLevel or something
                    // SceneChanger.sc.switchToScene("Level_2");
                    // }
                }
                else {
                    AnalyticsManager.analyticsManager.SendEvent("Level failed");
                    //GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
                }
                GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
        }
                
            // CountDownText.text = "Time Left: " + curTime.ToString ("0") + " Secs";
            CountDownText.text = curTime.ToString("0");
        // }
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

    public float getStartingTime() {
        return startingTime;
    }
    public int getTimeLeft()
    {
        if (curTime > 0)
            return (int) curTime;

        return 0;
        
    }
}
