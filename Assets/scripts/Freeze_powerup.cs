using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


// publisher class for event hitting freeze_bubble
public class Freeze_powerup : MonoBehaviour
{
    //public GameObject Animator;
    //public ParticleSystem ps;
    [SerializeField] Vector3 force;
    //[SerializeField] Sprite[] bubbleSprites;
    //[SerializeField] Sprite bubbleSprite;

    //public char symbol;
    //private Rigidbody2D rb;
    //private SpriteRenderer spriteRenderer;
    //private Animator anim;

    // declare delegate type freezePowerupHandler for our event inside class
    public delegate void freezePowerupDel();

    //// declare event freezeEventLog inside class
    public static event freezePowerupDel FreezeEvent;

    // Start is called before the first frame update
    void Start()
    {
        //ps = Animator.gameObject.GetComponent<ParticleSystem>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if (collision.gameObject.tag == "TopWall")
        //{
        //    Destroy(this.gameObject, 0.6f);
        //}
        if (collision.gameObject.name == "Arrow")
        {
            //Debug.Log("Freeze");
            FreezeEvent?.Invoke();
            //AnalyticsManager.analyticsManager.SendEvent("Freeze powerup hit");
            //Debug.Log("Freeze powerup hit");

            this.gameObject.SetActive(false);

            //anim.Play("BubblePop");
            //Destroy(this.gameObject, 0.6f);

            //transform.GetComponent<Publisher>().PublishFreezeEvent();
            //Bubble bubble_script = gameObject.GetComponent<Bubble>();
            //bubble_script.m_MyEvent.Invoke();

            //GetComponent(gameObject.tag == "letter");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Terrains")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.name == "Arrow")
        {
            Debug.Log("Freeze");
            //FreezeEvent?.Invoke();
            ////AnalyticsManager.analyticsManager.SendEvent("Freeze powerup hit");
            ////Debug.Log("Freeze powerup hit");

            //this.gameObject.SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }


    //public void EventProgram()
    //{
    //    this.freezeEventLog += new freezePowerupHandler(this.freezePowerup);
    //}


    //The preceding code defines a delegate named BoilerLogHandler and an event named BoilerEventLog,
    //which invokes the delegate when it is raised.

}


