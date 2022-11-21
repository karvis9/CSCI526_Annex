using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    public GameObject gm;
    public GameObject image;

    public GameObject blur;

    public float blurSize;

    
    void Awake() {
        // blur.GetComponent<Image>().material.SetFloat("_Size", 5.0F);
        // image.GetComponent<Image>().material.SetFloat("_Size", 1.0F);
        // thisRend.sharedMaterial.SetFloat("_Size", 5.0F);
        // thisRend.material.SetFloat("_Size", 5.0F);
        // Debug.Log("REdner " + thisRend);
        gm.SetActive(false);
    }

    void Update() {
        // Debug.Log("Enta blur size" + blurSize + thisRend.sharedMaterial.GetFloat("_Size"));
        // thisRend.sharedMaterial.SetFloat("_Size", 5.0F);
        // thisRend.material.SetFloat("_Size", 5.0F);
    }

    // void Start() {
    //     thisRend = blur.GetComponent<Renderer>();
    // }
    // Start is called before the first frame update
    public void showHint(string imageName){
        
        int timeLeft = CountDownTimer.countDownTimerObj.getTimeLeft();
        if (timeLeft > 10 && timeLeft < 30) {
            blurSize = 5.0F;
        } else if (timeLeft < 10) {
            blurSize = 1.0F;
        }
        gm.SetActive(true);
        string imageName1 = WordBlanks.wb.getWord();
        // Debug.Log("Get current word " + imageName1);
        Sprite hintImage = Resources.Load<Sprite>("Images/Hints/" + imageName);
        blur.GetComponent<Image>().material.SetFloat("_Size", blurSize);
        // Sprite hintImage = Resources.Load<Sprite>("Images/Hints/" + imageName1);
        image.GetComponent<Image>().sprite = hintImage;
        
    }

    public void closeHint() {
        Debug.Log("closing hint");
        gm.SetActive(false);
    }
}
