using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float LaunchForce;
    public GameObject Arrow;
    public bool spaceDown = true;

    public static shoot shootController;

    private int _arrowsCount;

    // Start is called before the first frame update
    void Start()
    {
        shootController = this;
        LaunchForce = 100;
        _arrowsCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.Space))
        // {
        //     LaunchForce += 400 * Time.deltaTime;
        // }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ;//LaunchForce = 600;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            LaunchForce = 600;
            Shoot();
        }

        if(Input.GetKeyUp("mouse 0"))
        {
            LaunchForce = 600;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject ArrowIns = Instantiate(Arrow, transform.position, transform.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
        _arrowsCount++;
    }

    public int getArrowsCount() { return _arrowsCount; }
}
