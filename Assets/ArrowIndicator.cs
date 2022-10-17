using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ArrowIndicator : MonoBehaviour
{
    static public ArrowIndicator arrowIndicator;
    public int arrows;
    public GameObject arrowOnBow;
    public GameObject arrow1;
    public GameObject countText;
    // Start is called before the first frame update
    void Start()
    {
        arrowIndicator = this;
        arrows = 5;
        updateArrowCnt();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void updateArrowCnt() {
        if(arrows >= 1) {
            arrowOnBow.SetActive(true);
            arrow1.SetActive(true);
            countText.SetActive(true);
            countText.GetComponent<TextMeshPro>().text = arrows.ToString();
            return;
        }
        else {
            countText.SetActive(false);
            arrow1.SetActive(false);
            arrowOnBow.SetActive(false);
        }
    }

    public void Add(int num) {
        arrows += num;
        updateArrowCnt();
    }

    public void Remove(int num) {
        arrows -= num;
        if(arrows < 0) {
            arrows = 0;
        }
        updateArrowCnt();
    }

    public void Set(int num) {
        arrows = num;
        if(arrows < 0) {
            arrows = 0;
        }
        updateArrowCnt();
    }

    public int Get() {
        return arrows;
    }
}
