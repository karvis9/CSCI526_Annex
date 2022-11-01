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
    public bool start;
    // Start is called before the first frame update
    void Start()
    {
        arrowIndicator = this;
        arrows = 20;
        start = true;
        updateArrowCnt();
        start = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void updateArrowCnt() {
        Debug.Log ("start value is" + start);
        if(arrows >= 1) {
            arrowOnBow.SetActive(true);
            arrow1.SetActive(true);
            countText.SetActive(true);
            countText.GetComponent<TextMeshPro>().text = arrows.ToString();
            if (start == false)
                ArrowsLeftText.arrowsLeftTextObj.updateArrowsLeft(arrows);
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
            string curLevel = SceneChanger.sc.getCurrentScene ().name;
            if (curLevel == "Level_0") {
                // SceneChanger.sc.switchToScene("Level_1");
                SceneChanger.sc.switchToNextLevel();
            }
            else if (curLevel == "Level_1" && ScoreManager.sm.getFinalScore() >= 1000) {
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
