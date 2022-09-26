using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class vCamScript : MonoBehaviour
{
    public GameObject arrow;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;
    public Transform initialTransform;
    public float initialLensOrth;
 
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }
 
    void Update()
    {
        if (arrow == null)
        {
            arrow = GameObject.FindWithTag("Arrow");
            if (arrow == null){
                setInitialPosition();
            }
            else{
                tFollowTarget = arrow.transform;
                vcam.LookAt = tFollowTarget;
                vcam.Follow = tFollowTarget;
                float init = vcam.m_Lens.OrthographicSize;
                vcam.m_Lens.OrthographicSize = Mathf.Lerp(init, 2.5f, Time.deltaTime / 5.0f);
            }
        }
        
    }
    void setInitialPosition(){
        Debug.Log("Set Init Pos");
    }
}
