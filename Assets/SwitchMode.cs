using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchMode : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshPro textsetting;
    void Start()
    {
        GameObject go = gameObject.transform.GetChild(0).gameObject;
        textsetting = go.GetComponent<TextMeshPro>();
        Debug.Log("12321321321" + go + " ");
        Debug.Log("12321321321" + go.GetComponent<TextMeshPro>() + " 123");
        textsetting.text = "123";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
