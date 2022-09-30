using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BubbleSpawner : MonoBehaviour
{
    // public TMP_Text characterText;
    public GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        Debug.Log(child.name);
        TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
        textmeshPro.text = "L";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
