using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // public void switchToMainScene(string category) {
    //     Debug.Log("Switching to main scene with category " + category);
    //     WordBlanks.callback(category);
    //     SceneManager.LoadScene("Level_0");
    //     // SceneManager.LoadScene("Level_2");
    //     //SceneManager.LoadScene("Level_1");
    // }
    public static SceneChanger sc;
    public static int curLevel = 0;

    void Start()
    {
        sc = this;
    }
    void Awake() {
        sc = this;
    }
    public void switchToScene(string SceneName) {
        Debug.Log("Switching to scene " + SceneName);
        if (SceneName == "FirstScene") {
            curLevel = 0;
        }
        SceneManager.LoadScene(SceneName);
    }

    public void switchToLevel(string category, string SceneName)
    {
        Debug.Log("category is  " + category);
        if (SceneName == "FirstScene")
        {
            curLevel = 0;
        }
        SceneManager.LoadScene(SceneName);
    }

    public void switchFromCategoryScene(string CategoryAndSceneName) {
        // This takes a string with Category selected and Scene to switch after the selection in the comma seperated fashion.
        // For example : Movies,Level_0
        string Category = CategoryAndSceneName.Split(",")[0];
        string SceneName = CategoryAndSceneName.Split(",")[1];
        Debug.Log("Switching from category scene to " + SceneName);
        PlayerPrefs.SetString("Category", Category);
        SceneManager.LoadScene(SceneName);
        curLevel = 1;
    }

    public void switchToNextLevel() {
        
        Debug.Log ("current level " + curLevel);
        if (SceneManager.GetActiveScene().name != "IntermediateScene"){
            AnalyticsManager.analyticsManager.SendEvent("Level Cleared");
            SceneChanger.sc.switchToScene("IntermediateScene");
        }
        else {
            shoot.readyToShoot = true;
            //SceneChanger.sc.switchToScene("Map_1");
         if (curLevel == 5)
            {
                GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
                curLevel = 0;
            }
         else if(curLevel == 0)
            {
                SceneChanger.sc.switchToScene("Map_New");
                curLevel = 1;
            }
         else if (curLevel == 1)
            {
                SceneChanger.sc.switchToScene("Map_New_level3");
                curLevel = 2;
            }
         else if (curLevel == 2)
            {
                SceneChanger.sc.switchToScene("Map_New_level4");
                curLevel = 3;
            }
        else if (curLevel == 3)
        {
            SceneChanger.sc.switchToScene("Map_New_level5");
            curLevel = 4;
        }
        else if (curLevel == 4)
            {
                SceneChanger.sc.switchToScene("Map_New_level2");
                curLevel = 5;
            }
            // else {
            //     curLevel += 1;
            //     SceneManager.LoadScene("Level_" + curLevel);
            // }
        }
    }

    public void replaySameLevel() {
        
        Debug.Log ("current level " + curLevel);
        if (SceneManager.GetActiveScene().name != "IntermediateScene"){
            AnalyticsManager.analyticsManager.SendEvent("Level Cleared");
            SceneChanger.sc.switchToScene("IntermediateScene");
        }
        else {
            shoot.readyToShoot = true;
            //SceneChanger.sc.switchToScene("Map_1");
         
            if(curLevel == 1)
            {
                SceneChanger.sc.switchToScene("Map_New");
                curLevel = 1;
            }
            else if (curLevel == 2)
            {
                SceneChanger.sc.switchToScene("Map_New_level3");
                curLevel = 2;
            }
            else if (curLevel == 3)
            {
                SceneChanger.sc.switchToScene("Map_New_level4");
                curLevel = 3;
            }
            else if (curLevel == 4)
            {
                SceneChanger.sc.switchToScene("Map_New_level5");
                curLevel = 4;
            }
            else if (curLevel == 5)
            {
                SceneChanger.sc.switchToScene("Map_New_level2");
                curLevel = 5;
            }
        }
    }

    public Scene getCurrentScene() {
        return SceneManager.GetActiveScene();
    }

    // public void switchToMainScene(string category) {
    //     Debug.Log("Switching to main scene with category " + category);
    //     WordBlanks.callback(category);
    //    // SceneManager.LoadScene("Level_0");
    //     //  SceneManager.LoadScene("MainScene_Arjun");
    // }

    // public void LoadFirstScene() 
    // {
    //     Debug.Log("Loading first scene");
    //     SceneManager.LoadScene("FirstScene");
    // }
}

