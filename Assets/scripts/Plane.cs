using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] Vector3 force;

    public char symbol;
    private Rigidbody2D rb;
    private GameObject player;
    public GameObject bombPrefab;
    public GameObject bomb;

    Vector3 initLocation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("bow");
        initLocation = transform.position; 

        rb = GetComponent<Rigidbody2D>();
        force = new Vector3(120, 0, 0);
        rb.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 1 && bomb == null)
        {
            Debug.Log("Drop Bomb");
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
            bomb = Instantiate(bombPrefab, pos, transform.rotation);
            bomb.SetActive(true);
        }

        if (transform.position.x > 40f)
        {
            transform.position = initLocation;
        }
    }
}
