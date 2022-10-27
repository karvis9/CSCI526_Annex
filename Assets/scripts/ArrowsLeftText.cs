using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowsLeftText : MonoBehaviour
{
    public static ArrowsLeftText arrowsLeftTextObj;

    // Start is called before the first frame update
    
    int arrowsLeft = 20;
    public Text arrowsLeftTextt;
    

    private ArrowsLeftText ()
    {

    }

    void Start()
    {
        arrowsLeft = 20;
        arrowsLeftTextObj = this;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void updateArrowsLeft(int arrows)
    {
        arrowsLeft = arrows;
        arrowsLeftTextt.text = "Arrows Left: " + arrowsLeft.ToString ("0");

    }
}
