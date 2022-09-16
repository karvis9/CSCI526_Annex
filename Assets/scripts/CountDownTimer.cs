using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public static CountDownTimer countDownTimerObj;

    // Start is called before the first frame update
    float curTime;
    float startingTime = 60f;
    public Text CountDownText;

    private CountDownTimer ()
    {

    }

    void Start()
    {
        curTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        curTime -= 1 * Time.deltaTime;
        if (curTime <= 0)
            curTime = 0

        CountDownText.text = curTime.ToString ("0");

        
    }
}
