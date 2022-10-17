using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private float speed = 1.5f;

    private GameObject player;

    // Start is called before the first frame update

    private float elapsed = 0;
    private float freezeTime = 0;
    private bool freeze = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("bow");
        elapsed =0;
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze && freezeTime <= 5)
        {
            freezeTime += Time.deltaTime;
            return;
        }
        freeze = false;
        freezeTime = 0;
        Swarm();
    }

    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player hit");
            CountDownTimer.countDownTimerObj.reduceTime(10);
            Message.msg.SendMessage("-10 Seconds!", Color.red, 2f);
            AnalyticsManager.analyticsManager.SendEvent("Enemey Touched");
        }
        if (collision.CompareTag("Arrow") && !freeze)
        {
            Debug.Log("Arrow hit");
            freeze = true;
            freezeTime = 0;
            AnalyticsManager.analyticsManager.SendEvent("Enemey Hit");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("bow"))
            return;

        elapsed += Time.deltaTime;
        //Debug.Log(elapsed);
        if (elapsed >= 5)
        {

            CountDownTimer.countDownTimerObj.reduceTime(5);
            Message.msg.SendMessage("-5 Seconds!", Color.red, 2f);
            AnalyticsManager.analyticsManager.SendEvent("Enemey Touched");

            elapsed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("bow"))
            return;

        //elapsed = 0;
    }

}
