using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleCounter : MonoBehaviour
{
    public TextMeshPro counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = this.gameObject.GetComponent<TextMeshPro>();
        Debug.Log(counter);
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = OptionBubble.oB.getSelectedCount().ToString()+"/10";
    }
}
