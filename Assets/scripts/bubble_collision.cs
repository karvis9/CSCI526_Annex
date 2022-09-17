using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bubble_collision : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private TextMeshProUGUI letterText;
    public GameObject local_bubble;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //GameObject gameObject1 = this.gameObject.FindObjectOfType<TextMeshProUGUI>();
        //letterText = gameObject1;
        local_bubble = this.gameObject;
        Debug.Log(local_bubble.transform.GetChild(0).GetComponent<TextMeshPro>().text);
        //Debug.Log(this.gameObject.transform.Find("letter").GetComponent<TMPro.TextMeshProUGUI>().text);
        // Destroy(col.gameObject);
        //Destroy(this.gameObject);
    }
}
