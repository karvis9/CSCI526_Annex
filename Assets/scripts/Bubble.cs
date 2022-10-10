using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 force;
    [SerializeField] Sprite[] bubbleSprites;
    [SerializeField] Sprite bubbleSprite;

    public char symbol;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Level_1")
        {
            transform.position = new Vector3(Random.Range(8f, 9f), Random.Range(-2.0f, 3.5f), transform.position.z);
            force = new Vector3(Random.Range(-200, -350), Random.Range(0, 10), 0);
        }
        else
        {
            transform.position = new Vector3(Random.Range(-4f, 9f), Random.Range(-2.0f, 3.5f), transform.position.z);
            force = new Vector3(Random.Range(-30, 30), Random.Range(20, 50), 0);
        }
        rb.AddForce(force);
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if(collision.gameObject.tag == "TopWall")
        {
            Destroy(this.gameObject,0.6f);
        }
        if(collision.gameObject.tag == "Arrow")
        {
            anim.Play("BubblePop");
            Destroy(this.gameObject,0.6f);
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
