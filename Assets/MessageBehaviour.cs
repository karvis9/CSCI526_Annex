using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MessageBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    public Color color;
    public string text;

    public Vector3 startPos;
    public Vector3 endPos;
    public float animationTime;

    private bool animationOver;
    private TextMeshPro setting;
    private float timeElapsed;
    public void Start()
    {
        setting = gameObject.GetComponent<TextMeshPro>();
        setting.color = color;
        setting.text = text;
        timeElapsed = 0f;
        animationOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(!animationOver && timeElapsed <= animationTime) {
            transform.localPosition = startPos + (endPos - startPos) * (timeElapsed / animationTime);
            Color c = setting.color;
            c.a = timeElapsed / animationTime;
            setting.color = c;
        }
        else {
            animationOver = true;
            transform.localPosition = endPos;
            Color c = setting.color;
            c.a = 1.0f;
            setting.color = c;
        }
        if(timeElapsed >= time) {
            Destroy(gameObject);
        }
    }

    float Sigmoid(float x) {
        return 1.0f / (1.0f + (float) Math.Exp(-x));
    }
}
