using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class shoot : MonoBehaviour
{
    public float LaunchForce;
    private float MaxLaunchForce = 16;
    public GameObject Arrow;
    public static shoot shootController;
    private int _arrowsCount;
    public Image powerBar;
    private IEnumerator UpdatePowerBarCoRoutine;
    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberofPoints;
    public CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        shootController = this;
        _arrowsCount = 0;
        LaunchForce = 5;
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
        if (Input.GetKey(KeyCode.Space))
        {
            vcam.m_Priority = 1;
            LaunchForce += 8 * Time.deltaTime;
            LaunchForce = Mathf.Min(MaxLaunchForce, LaunchForce);
            StartCoroutine(UpdatePowerBarCoRoutine);
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].SetActive(true);
                Vector2 pos = PointPosition(i * 0.05f);
                Points[i].transform.position = pos;
            }
        }
        if (Input.GetKey("mouse 0"))
        {
            vcam.m_Priority = 1;
            LaunchForce += 8 * Time.deltaTime;
            LaunchForce = Mathf.Min(MaxLaunchForce, LaunchForce);
            StartCoroutine(UpdatePowerBarCoRoutine);
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].SetActive(true);
                Vector2 pos = PointPosition(i * 0.05f);
                Points[i].transform.position = pos;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
            powerBar.fillAmount = 0;
            LaunchForce = 5;
            StopCoroutine(UpdatePowerBarCoRoutine);
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].SetActive(false);
            }
        }

        if (Input.GetKeyUp("mouse 0"))
        {
            Shoot();
            powerBar.fillAmount = 0;
            LaunchForce = 5;
            StopCoroutine(UpdatePowerBarCoRoutine);
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].SetActive(false);
            }
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
        GameObject ArrowIns = Instantiate(Arrow, transform.position, transform.rotation);
        //ArrowIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        ArrowIns.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        _arrowsCount++;
        vcam.m_Priority = 3;
    }

    public int getArrowsCount() { return _arrowsCount; }
}
