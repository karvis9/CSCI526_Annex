using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public static CountDownTimer countDownTimerObj;

    // Start is called before the first frame update
    float curTime;
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
        curTime -= 1 * Time.deltaTime;
        if (curTime <= 0)
            GameOverScreen.gm.EndGame(ScoreManager.sm.getFinalScore(), false);

        CountDownText.text = "Time Left: " + curTime.ToString ("0") + " Secs";

      
    }

    public int getTimeLeft()
    {
        if (curTime > 0)
            return (int) curTime;

        return 0;
        
    }
}
