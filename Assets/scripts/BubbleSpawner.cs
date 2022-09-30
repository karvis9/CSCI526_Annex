using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BubbleSpawner : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        GameObject child = transform.GetChild(0).gameObject;
        TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
        textmeshPro.text = "A";
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Arrow")
        {
            anim.Play("BubblePop");
            Destroy(this.gameObject,0.6f);
        }
    }

}
