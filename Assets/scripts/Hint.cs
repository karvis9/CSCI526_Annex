using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hint : MonoBehaviour
{
    public GameObject hintGm;
    private string curLevelScene;

    private string imageName;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showHint(string curLevel_imageName) {
        Debug.Log("Loading hint");
        curLevelScene = curLevel_imageName.Split(",")[0];
        imageName = curLevel_imageName.Split(",")[1];
        this.curLevelScene = curLevelScene;
        Sprite hintImage = Resources.Load<Sprite>("Images/Hints/" + imageName);
        Debug.Log("Got the image " + hintImage);
        hintGm.GetComponent<Image>().sprite = hintImage;
    }

    public void closeHintScene() {
        Debug.Log("closing hint");
        SceneManager.LoadScene(curLevelScene);
    }

    public void something(){

    }
}
