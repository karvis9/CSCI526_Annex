using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bubble : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 force;

    public char symbol;
    private GameObject bubble;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private Vector3[] vector3s = new Vector3[4];

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
        bubble = this.transform.GetChild(0).gameObject;
        if(bubble)
            symbol = bubble.GetComponent<TMP_Text>().text[0];

        vector3s[0] = new Vector3(-3.6f, -0.5f, transform.position.z);
        vector3s[1] = new Vector3(-1.04f, -0.98f, transform.position.z);
        vector3s[2] = new Vector3(6.6f, 0.4f, transform.position.z);
        vector3s[3] = new Vector3(4.42f, 0.32f, transform.position.z);

        //rb = GetComponent<Rigidbody2D>();
        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;

        //if (sceneName == "Level_2")
        //{
        //    transform.position = new Vector3(Random.Range(8f, 9f), Random.Range(-2.0f, 3.5f), transform.position.z);
        //    force = new Vector3(Random.Range(-200, -350), Random.Range(0, 10), 0);
        //}
        //else if (sceneName == "Level_0")
        //{
        //    // transform.position = new Vector3(Random.Range(8f, 9f), Random.Range(-2.0f, 3.5f), transform.position.z);
        //    // force = new Vector3(Random.Range(-200, -350), Random.Range(0, 10), 0);
        //}
        //else if (sceneName == "Level_1")
        //{
        //    transform.position = vector3s[Random.Range(0,3)];
        //    force = new Vector3(Random.Range(-30, 30), Random.Range(20, 50), 0);
        //}
        //else
        //{
        //    transform.position = new Vector3(Random.Range(-4f, 9f), Random.Range(-2.0f, 3.5f), transform.position.z);
        //    force = new Vector3(Random.Range(-30, 30), Random.Range(20, 50), 0);
        //}
        //rb.AddForce(force);
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
        if(collision.gameObject.tag == "HintArrowTag")
        {
            // anim.Play("BubblePop");
            // if(WordBlanks.wb.isCorrect(symbol)){
            //     turnGreen();
            // }
            // else
            //     turnRed();
            StartCoroutine(ChangeColor("red"));
            // StartCoroutine(ChangeColor("green"));
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
    IEnumerator ChangeColor(string color){
        if(color=="red")
            TurnRed();
        else
            TurnGreen();
        yield return new WaitForSeconds(2);
        TurnWhite();
    }
    public void TurnRed()
     {
        sr.color = Color.red;
     }
     public void TurnGreen()
     {
        sr.color = Color.green;
     }
     public void TurnWhite()
     {
        sr.color = Color.white;
     }
}
