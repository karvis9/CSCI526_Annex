using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void switchToMainScene(string category) {
        Debug.Log("Switching to main scene with category " + category);
        WordBlanks.callback(category);
        SceneManager.LoadScene("Level_0");
        // SceneManager.LoadScene("MainScene_Arjun");
    }

    public void LoadFirstScene() 
    {
        Debug.Log("Loading first scene");
        SceneManager.LoadScene("FirstScene");
    }
}
