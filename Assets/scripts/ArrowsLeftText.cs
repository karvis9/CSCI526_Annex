using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ArrowsLeftText : MonoBehaviour
{
    public static ArrowsLeftText arrowsLeftTextObj;

    // Start is called before the first frame update
    
    float arrowsLeft = 20f;
    public Text arrowsLeftText;
    

    private ArrowsLeftText ()
    {

    }

    void Start()
    {
        arrowsLeft = 20f;
        arrowsLeftTextObj = this;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void updateArrowsLeft(float arrows)
    {
        arrowsLeft = arrows;
        arrowsLeftText.text = "Arrows Left: " + arrowsLeft.ToString ("0");

    }
}
