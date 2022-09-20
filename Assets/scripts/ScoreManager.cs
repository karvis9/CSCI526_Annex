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
        return points + timeLeft * timeLeftWeightage;
    }
}
