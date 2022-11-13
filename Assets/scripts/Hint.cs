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
    public void showHint(string imageName){
        gm.SetActive(true);
        Sprite hintImage = Resources.Load<Sprite>("Images/Hints/" + imageName);
        image.GetComponent<Image>().sprite = hintImage;
    }

    public void closeHint() {
        Debug.Log("closing hint");
        gm.SetActive(false);
    }
}
