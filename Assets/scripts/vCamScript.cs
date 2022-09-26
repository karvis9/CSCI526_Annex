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
            vcam.LookAt = arrow.transform;
            vcam.Follow = arrow.transform;
            vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, 2.5f, Time.deltaTime / 5.0f);
        }
        
    }
    void setInitialPosition(){
        vcam.LookAt = null;
        vcam.Follow = null;
        vcam.transform.position = initialTransform.position;
        vcam.m_Lens.OrthographicSize = Mathf.Lerp(vcam.m_Lens.OrthographicSize, initialLensOrth, 0.5f);
        Debug.Log("Set Init Pos");
    }
}
