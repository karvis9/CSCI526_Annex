using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    public GameObject textPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //SendMessage("123", Color.blue, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendMessage(string text, Color color, float time) {
        GameObject obj = Instantiate(textPrefab, transform);
        MessageBehaviour property = obj.GetComponent<MessageBehaviour>();
        property.color = color;
        property.text = text;
        property.time = time;//LifeCycle Time

        //If you wanna change these you can, add them to the SendMessage parameters
        property.startPos = new Vector3(0, 0.2f, 0);
        property.endPos = new Vector3(0, 0.25f, 0);
        property.animationTime = 0.6f;
        obj.SetActive(true);
    }
}
