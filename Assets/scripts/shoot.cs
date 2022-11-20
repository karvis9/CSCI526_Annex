using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class shoot : MonoBehaviour
{
    public float LaunchForce;
    public float DefaultLaunchForce = 5;
    public float MaxLaunchForce = 16;
    public GameObject Arrow;
    public GameObject HintArrow;
    public static shoot shootController;
    private int _arrowsCount;
    public Image powerBar;
    private IEnumerator UpdatePowerBarCoRoutine;
    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberofPoints;
    // public CinemachineVirtualCamera vcam;
    public static bool readyToShoot;
    public static int ArrowMode;
    public float pointPadding = 0.05f;
    public float LaunchForceIntensity = 8;

    // Start is called before the first frame update
    void Start()
    {
        ArrowMode = 0;
        readyToShoot = true;
        shootController = this;
        _arrowsCount = 0;
        LaunchForce = DefaultLaunchForce;
        UpdatePowerBarCoRoutine = UpdatePowerBar();
        Points = new GameObject[numberofPoints];
        for (int i = 0; i < numberofPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
            Points[i].SetActive(false);
        }
    }

    Vector2 PointPosition(float t)
    {
        Vector2 direction;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        
        direction = this.gameObject.GetComponent<bow>().direction;
        
        //Vector2 startPosition = transform.right;
        //transform.right = Vector2.Lerp(startPosition, direction, Time.deltaTime / 1.2f);
        Vector2 currentPointPos = (Vector2)transform.position + (LaunchForce * t * direction.normalized) + 0.5f * Physics2D.gravity * t * t;
        // Debug.Log(currentPointPos);
        return currentPointPos;
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log("Ready to shoot " + readyToShoot);
        if(ArrowMode == 1 && ArrowsLeftText.arrowsLeftTextObj.GetHint() == 0) {
            return;
        }
        if(ArrowsLeftText.arrowsLeftTextObj.Get() == 0) {
            return;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // vcam.m_Priority = 1;
            if(!readyToShoot)
                return;
            LaunchForce += LaunchForceIntensity * Time.deltaTime;
            LaunchForce = Mathf.Min(MaxLaunchForce, LaunchForce);
            StartCoroutine(UpdatePowerBarCoRoutine);
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].SetActive(true);
                Vector2 pos = PointPosition(i * pointPadding);
                Points[i].transform.position = pos;
            }
        }
        if (Input.GetKey("mouse 0"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                if(mousePos.x / Screen.width > 0.8)
                    return;
                if(mousePos.x/ Screen.width < 0.06)
                    return;
            }
            // vcam.m_Priority = 1;
            if(!readyToShoot)
                return;
            LaunchForce += LaunchForceIntensity * Time.deltaTime;
            LaunchForce = Mathf.Min(MaxLaunchForce, LaunchForce);
            StartCoroutine(UpdatePowerBarCoRoutine);
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].SetActive(true);
                Vector2 pos = PointPosition(i * pointPadding);
                Points[i].transform.position = pos;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].SetActive(false);
            }
            if (!readyToShoot)
                return;
            Shoot();
            if(ArrowMode == 0){
                ArrowsLeftText.arrowsLeftTextObj.Remove(1);
            }
            else{
                ArrowsLeftText.arrowsLeftTextObj.RemoveHint(1);
            }
            powerBar.fillAmount = 0;
            LaunchForce = DefaultLaunchForce;
            StopCoroutine(UpdatePowerBarCoRoutine);
        }

        if (Input.GetKeyUp("mouse 0"))
        {
            Vector3 mousePos = Input.mousePosition;
            {
                if (mousePos.x / Screen.width > 0.8)
                    return;
                if (mousePos.x / Screen.width < 0.06)
                    return;
            }
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].SetActive(false);
            }
            if (!readyToShoot)
                return;
            Shoot();
            if(ArrowMode == 0){
                ArrowsLeftText.arrowsLeftTextObj.Remove(1);
            }
            else{
                ArrowsLeftText.arrowsLeftTextObj.RemoveHint(1);
            }
            powerBar.fillAmount = 0;
            LaunchForce = DefaultLaunchForce;
            StopCoroutine(UpdatePowerBarCoRoutine);
        }
    }

    IEnumerator UpdatePowerBar()
    {
        while (true)
        {
            powerBar.fillAmount = (LaunchForce - 5) / (MaxLaunchForce - 5);
            //Debug.Log(LaunchForce/MaxLaunchForce);
            yield return new WaitForSeconds(0.06f);
        }
        yield return null;
    }
    void Shoot()
    {
        GameObject ArrowIns = null;
        if(ArrowMode == 0){
            ArrowIns = Instantiate(Arrow, transform.position, transform.rotation);
            _arrowsCount++;
        }
        else{
            ArrowIns = Instantiate(HintArrow, transform.position, transform.rotation);
        }
        readyToShoot = false;
        //ArrowIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        ArrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        //vcam.m_Priority = 3;
    }

    public int getArrowsCount() { return _arrowsCount; }
}
