using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public GameObject gm;
    public GameObject image;
    void Awake() {
        gm.SetActive(false);
    }
    // Start is called before the first frame update
    public void showHint(string curLevel_imageName){
        gm.SetActive(true);
        string curLevelScene = curLevel_imageName.Split(",")[0];
        string imageName = curLevel_imageName.Split(",")[1];
        Sprite hintImage = Resources.Load<Sprite>("Images/Hints/" + imageName);
        image.GetComponent<Image>().sprite = hintImage;
        // PlayerPrefs.SetString("curLevelScene", curLevelScene);
        // PlayerPrefs.SetString("imageName", imageName);
        // PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        // PlayerPrefs.Save();
        // SceneManager.LoadScene("HintScene");
    }

    public void closeHint() {
        Debug.Log("closing hint");
        gm.SetActive(false);
    }
}
