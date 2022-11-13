using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeArrowMode : MonoBehaviour
{
    Image childImageObj;
    bool NormalMode;
    // Start is called before the first frame update
    void Start()
    {
        NormalMode = true;
        childImageObj = this.transform.GetChild(0).gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeArrowModeFunction(){
        NormalMode = !NormalMode;
        if(NormalMode){
            shoot.ArrowMode = 0;
            childImageObj.color = Color.black;
        }
        else{
            shoot.ArrowMode = 1;
            childImageObj.color = Color.red;
        }
    }
}
