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
    float startingTime = 120f;
    public Text CountDownText;
    public float minutes;
    public float seconds;

    private CountDownTimer ()
    {

    }

    void Start()
    {
        Debug.Log("text"+SceneChanger.sc.getCurrentScene().ToString());
        startingTime = 120f;
        if (SceneChanger.sc.getCurrentScene().name == "Level_1")
            startingTime = 60f;
        curTime = startingTime;
        countDownTimerObj = this;
        Debug.Log(countDownTimerObj);
    }

    // Update is called once per frame
    void Update()
    {
        // if (!GameOverScreen.gm.gameEnded) {
            curTime -= (1 * Time.deltaTime);
            string curLevel = SceneChanger.sc.getCurrentScene ().name;
            if (curTime <= 0){
                if (curLevel == "Level_1" && ScoreManager.sm.getFinalScore() >= 1000) {
                    SceneChanger.sc.switchToNextLevel();
                    // Scene scene = SceneChanger.sc.getCurrentScene();
                    // string level = scene.name.Split("_")[1];
                    // if (level == "2"){
                    //     GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
                    // } else {
                    //     // Change this to call loadNextLevel or something
                    // SceneChanger.sc.switchToScene("Level_2");
                    // }
                } else if (curLevel == "Level_2" && ScoreManager.sm.getFinalScore() >= 2000) {
                    SceneChanger.sc.switchToNextLevel();
                } else if (curLevel == "Level_3" && ScoreManager.sm.getFinalScore() >= 3000) {
                    SceneChanger.sc.switchToNextLevel();
                } else if (curLevel == "Level_4" && ScoreManager.sm.getFinalScore() >= 4000) {
                    SceneChanger.sc.switchToNextLevel();
                }
                else {
                    AnalyticsManager.analyticsManager.SendEvent("Level failed");
                    GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
                }
            }

            minutes = (int) (curTime / 60f);
            seconds = (int) (curTime % 60f);
                
            CountDownText.text = "Time Left: " + minutes.ToString ("00") + ":" + seconds.ToString ("00");
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

    public int getTimeLeft()
    {
        if (curTime > 0)
            return (int) curTime;

        return 0;
        
    }
}
