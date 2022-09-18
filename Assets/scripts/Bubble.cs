using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 force;
    [SerializeField] Sprite[] bubbleSprites;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bubbleSprites[Random.Range(0, 4)];
        transform.position = new Vector3(Random.Range(-6.1f, 9.18f), transform.position.y, transform.position.z);
        force = new Vector3(Random.Range(-50, 50), Random.Range(50, 100) ,0);
        rb.AddForce(force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TopWall")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
