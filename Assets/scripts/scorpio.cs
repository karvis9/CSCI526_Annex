using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorpio : MonoBehaviour
{
    private bool moveingRight;
    public float speed = 1.6f;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        moveingRight = true;
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //if we want to track the payer object
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        if (moveingRight == true) {
            this.transform.Translate(-1.0f*speed*Time.deltaTime,0,0);
            if (transform.position.x <= -7) {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveingRight = false;
            }       
        }
        else {
            this.transform.Translate(-1.0f*speed*Time.deltaTime,0,0);
            if (transform.position.x >= 7) {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveingRight = true;
            }  
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.name);

        //decrease time below is increasing
        if(collision.gameObject.name == "Player"){
            //play animation
            anim.Play("Hit");
            CountDownTimer.countDownTimerObj.reduceTime(10);
        }

    }
}
