using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ArrowIndicator : MonoBehaviour
{
    static public ArrowIndicator arrowIndicator;
    public int arrows;
    public GameObject arrowOnBow;
    public GameObject arrow1;
    public GameObject countText;
    // Start is called before the first frame update
    void Start()
    {
        arrowIndicator = this;
        arrows = 20;
        updateArrowCnt();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void updateArrowCnt() {
        if(arrows >= 1) {
            arrowOnBow.SetActive(true);
            arrow1.SetActive(true);
            countText.SetActive(true);
            countText.GetComponent<TextMeshPro>().text = arrows.ToString();
            return;
        }
        else {
            countText.SetActive(false);
            arrow1.SetActive(false);
            arrowOnBow.SetActive(false);
        }
    }

    public void Add(int num) {
        arrows += num;
        updateArrowCnt();
    }

    public void Remove(int num) {
        arrows -= num;
        Debug.Log ("arrows left " + arrows);
        if(arrows <= 0) {
            arrows = 0;
            Debug.Log ("No more arrows left");

            if (SceneChanger.sc.getCurrentScene().name == "Level_0") {
                // SceneChanger.sc.switchToScene("Level_1");
                SceneChanger.sc.switchToNextLevel();
            }
            else if (ScoreManager.sm.getFinalScoreNoArrowsLeft() >= 400) {
                SceneChanger.sc.switchToNextLevel();
                // Scene ss = SceneChanger.sc.getCurrentScene();
                // string scene = ss.name;
                // if (scene == "Level_5"){
                //     GameOverScreen.EndGame(ScoreManager.sm.getFinalScoreNoArrowsLeft(), false, WordBlanks.wb.word);
                // } else {
                //     SceneChanger.sc.switchToNextLevel();
                // }
                // } else if (scene == "Level_1"){
                //     SceneChanger.sc.switchToScene("Level_2");    
                // }  
                // else {
                //     // Change this to call loadNextLevel or something
                // SceneChanger.sc.switchToScene("Level_3");
                // }
            } else {
                AnalyticsManager.analyticsManager.SendEvent("Level failed");
                GameOverScreen.EndGame(ScoreManager.sm.getFinalScoreNoArrowsLeft(), false, WordBlanks.wb.word);
            }     
        }
        updateArrowCnt();
    }

    public void Set(int num) {
        arrows = num;
        if(arrows < 0) {
            arrows = 0;
        }
        updateArrowCnt();
    }

    public int Get() {
        return arrows;
    }
}
