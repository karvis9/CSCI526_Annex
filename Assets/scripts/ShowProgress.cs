using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowProgress : MonoBehaviour
{
    
    public static ShowProgress sp;
    
    // Layout
    public Transform letterHolder;

    bool isUp = true;
    void Start()
    {
        sp = this;
    }

    public void showProgress() {
        Debug.Log (letterHolder.position.y);
        if (isUp){
             
            letterHolder.position = new Vector3(letterHolder.position.x, letterHolder.position.y - 2f, letterHolder.position.z);
            isUp = false;
        }
        else {
            letterHolder.position = new Vector3(letterHolder.position.x, letterHolder.position.y + 2f, letterHolder.position.z);
            isUp = true;
        } 
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

