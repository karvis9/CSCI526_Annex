using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public GameObject gm;
    public GameObject image;

    public GameObject blur;

    public float blurSize;

    
    void Awake() {
        gm.SetActive(false);
    }
    public void showHint(){
        float startingTime = CountDownTimer.countDownTimerObj.getStartingTime();
        int timeLeft = CountDownTimer.countDownTimerObj.getTimeLeft();
        
        float timePercent = (timeLeft / startingTime) * 100;
        if (timePercent > 75) {
            blurSize = 15.0F;
        } else if(timePercent > 50) {
            blurSize = 10.0F;
        } else if (timePercent > 25) {
            blurSize = 5.0F;
        } else {
            blurSize = 0.0F;
        }

        gm.SetActive(true);
        string imageName = WordBlanks.wb.getWord();
        // Sprite hintImage = Resources.Load<Sprite>("Images/Hints/" + imageName);
        Sprite hintImage = Resources.Load<Sprite>("Images/Hints/test");
        blur.GetComponent<Image>().material.SetFloat("_Size", blurSize);
        image.GetComponent<Image>().sprite = hintImage;
        
    }

    public void closeHint() {
        Debug.Log("closing hint");
        gm.SetActive(false);
    }
}
