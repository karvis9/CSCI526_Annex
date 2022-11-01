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
        Debug.Log (SceneChanger.sc.getCurLevel ());

        if (isUp){
            if (SceneChanger.sc.getCurLevel () < 2)
                letterHolder.position = new Vector3(letterHolder.position.x, letterHolder.position.y - 2.2f, letterHolder.position.z);
            else
                letterHolder.position = new Vector3(letterHolder.position.x, letterHolder.position.y - 100f, letterHolder.position.z);
            isUp = false;
        }
        else {
            if (SceneChanger.sc.getCurLevel () < 2)
                letterHolder.position = new Vector3(letterHolder.position.x, letterHolder.position.y + 2.2f, letterHolder.position.z);
            else
                letterHolder.position = new Vector3(letterHolder.position.x, letterHolder.position.y + 100f, letterHolder.position.z);
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

