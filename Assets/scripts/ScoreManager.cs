using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager sm;
    public int points = 0;
    public int timeLeftWeightage = 2;


    private ScoreManager ()
    {
        
    }

    void Start()
    {
        points = 0;
        sm = this;
    }
    public int getCurrentPoint(){
        return points;
    }
    public void increasePoint(){
         points+=100; 
    }

    public int getFinalScore()
    {
        int timeLeft = CountDownTimer.countDownTimerObj.getTimeLeft();
        Debug.Log("Points " + points);
        return points + timeLeft * timeLeftWeightage;
    }

    public int getFinalScoreNoArrowsLeft ()
    {
        return points;
    }

}
