using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneArrow : MonoBehaviour
{
    [SerializeField] Vector3 force;
    private Rigidbody2D rb;
    public GameObject hintArrow;
    public  bool isFalling = false;
    Vector3 initLocation;

    // Start is called before the first frame update
    void Start()
    {
        initLocation = transform.position; 
        rb = GetComponent<Rigidbody2D>();
        force = new Vector3(120, 0, 0);
        rb.AddForce(force);
    }

    

        // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 40f)
        {
            if(isFalling)
                Destroy(this.gameObject);
            transform.position = initLocation;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Destroy(collision.gameObject);
            rainShower();
        }
    }
    public void rainShower()
    {
        if(!isFalling){
            for (int i = 1; i < 40; i += 1)
            {
                Vector3 pos = new Vector3(transform.position.x + 2, transform.position.y, 0);
                GameObject hintArrowTemp = null;

                hintArrowTemp = Instantiate(hintArrow, pos, transform.rotation);
                hintArrowTemp.GetComponent<Rigidbody2D>().velocity = transform.right * 6 * Random.Range(0.1f, 2f);
                hintArrowTemp.SetActive(true);
            }
        }
        isFalling = true;
    }
}
