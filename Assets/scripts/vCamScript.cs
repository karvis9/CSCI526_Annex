using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class vCamScript : MonoBehaviour
{
    public GameObject arrow;
    private CinemachineVirtualCamera vcam;
    private Transform initialTransform;
    private float initialLensOrth;
 
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        initialTransform = vcam.transform;
        initialLensOrth = 5f;
    }
 
    void Update()
    {
        if (arrow == null)
        {
            arrow = GameObject.FindWithTag("Arrow");
            if (arrow == null){
                setInitialPosition();
            }
        }
        else{
            vcam.m_Priority = 3;
            vcam.LookAt = arrow.transform;
            vcam.Follow = arrow.transform;
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, 4.3f, Time.deltaTime / 2.0f);
        }
        
    }
    void setInitialPosition(){
        vcam.m_Priority = 1;
        vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, initialLensOrth, 0.5f);
    }
}
