using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 force;
    [SerializeField] Sprite[] bubbleSprites;
    [SerializeField] Sprite bubbleSprite;

    public char symbol;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = bubbleSprites[Random.Range(0, 4)];
        //Debug.Log("Sprite: " + spriteRenderer.sprite.name);
        spriteRenderer.sprite = bubbleSprite;
        transform.position = new Vector3(Random.Range(-4f, 9f), Random.Range(-2.0f, 3.5f), transform.position.z);
        force = new Vector3(Random.Range(-20, 20), Random.Range(20, 50) ,0);
        rb.AddForce(force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if(collision.gameObject.tag == "TopWall")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Terrains"){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
