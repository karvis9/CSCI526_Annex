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
        arrows = 5;
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
                SceneChanger.sc.switchToScene("Level_0_1");
            }
            else if (ScoreManager.sm.getFinalScore() >= 400) {
                Scene ss = SceneChanger.sc.getCurrentScene();
                string scene = ss.name;
                if (scene == "Level_2"){
                    GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
                } else if (scene == "Level_0_1"){
                    SceneChanger.sc.switchToScene("Level_1");    
                }  
                else {
                    // Change this to call loadNextLevel or something
                SceneChanger.sc.switchToScene("Level_2");
                }
            } else {
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
