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

    void Start()
    {
        sc = this;
    }

    public void switchToScene(string SceneName) {
        Debug.Log("Switching to scene " + SceneName);
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

