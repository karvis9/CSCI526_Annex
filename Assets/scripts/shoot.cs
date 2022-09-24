using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    public float LaunchForce;
    private float MaxLaunchForce = 700;
    public GameObject Arrow;
    public static shoot shootController;
    private int _arrowsCount;
    public Image powerBar;
    private IEnumerator UpdatePowerBarCoRoutine;
    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberofPoints;

    // Start is called before the first frame update
    void Start()
    {
        shootController = this;
        _arrowsCount = 0;
        LaunchForce = 200;
        UpdatePowerBarCoRoutine = UpdatePowerBar();
        Points = new GameObject[numberofPoints];
        for (int i = 0; i < numberofPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
    }

    Vector2 PointPosition(float t)
    {
        Vector2 direction = this.gameObject.GetComponent<bow>().direction;
        Vector2 startPosition = transform.right;
        transform.right = Vector2.Lerp(startPosition, direction, Time.deltaTime / 1.2f);
        Vector2 currentPointPos = (Vector2)transform.position + (direction.normalized * LaunchForce * t) + 0.5f * Physics2D.gravity * t * t;
        // Debug.Log(currentPointPos);
        return currentPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            LaunchForce += 400 * Time.deltaTime;
            StartCoroutine(UpdatePowerBarCoRoutine);
        }
        if(Input.GetKey("mouse 0"))
        {
            LaunchForce += 400 * Time.deltaTime;
            StartCoroutine(UpdatePowerBarCoRoutine);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            LaunchForce = Mathf.Min(MaxLaunchForce,LaunchForce);
            Shoot();
            powerBar.fillAmount = 0;
            LaunchForce = 200;
            StopCoroutine(UpdatePowerBarCoRoutine);
        }

        if(Input.GetKeyUp("mouse 0"))
        {
            LaunchForce = Mathf.Min(MaxLaunchForce,LaunchForce);
            Shoot();
            powerBar.fillAmount = 0;
            LaunchForce = 200;
            StopCoroutine(UpdatePowerBarCoRoutine);
        }

        for (int i = 0; i < Points.Length; i++)
        {
            Vector2 pos = PointPosition(i * 0.001f);
            Points[i].transform.position = pos;
        }
    }

    IEnumerator UpdatePowerBar(){
        while(true){
            powerBar.fillAmount = (LaunchForce-200)/(MaxLaunchForce-200);
            //Debug.Log(LaunchForce/MaxLaunchForce);
            yield return new WaitForSeconds(0.06f);
        }
        yield return null;
    }
    void Shoot()
    {
        GameObject ArrowIns = Instantiate(Arrow, transform.position, transform.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        _arrowsCount++;
    }

    public int getArrowsCount() { return _arrowsCount; }
}
