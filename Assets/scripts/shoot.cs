using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public float LaunchForce;
    public GameObject Arrow;
    public bool spaceDown = true;
    // Start is called before the first frame update
    void Start()
    {
        LaunchForce = 150;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            LaunchForce += 400 * Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            LaunchForce = Mathf.Min(700,LaunchForce);
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
    }
}
