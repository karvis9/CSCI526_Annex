using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class arrowScript : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasHit == false)
        {
            trackMovement();
        }
        
    }

    void trackMovement()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other) {
         Debug.Log("Entered the trigger");
        if(this.gameObject.tag != "HintArrowTag"){
            if(other.gameObject.tag == "Letter"){
                //char symbol = other.gameObject.GetComponent<Bubble>().symbol;// might fix this later
                GameObject child = other.transform.GetChild(0).gameObject;
                TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
                Debug.Log("Hit: "+textmeshPro.text);
                if(textmeshPro.text.Equals("+5"))
                {
                    Message.msg.SendMessage("+5 Seconds!", Color.green, 2f);
                    AnalyticsManager.analyticsManager.SendEvent("Power up: +5");
                    CountDownTimer.countDownTimerObj.updateTime();
                }
    /*            Scene currentScene = SceneManager.GetActiveScene();
                string sceneName = currentScene.name;
                if (sceneName)
                {*/

                    WordBlanks.wb.TargetHit(textmeshPro.text[0]); 
                //}
            }
            else if(other.gameObject.tag == "extraArrow") {
                Debug.Log("Extra arrow");
                ArrowsLeftText.arrowsLeftTextObj.Add(3);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log( "Collided with : " + collision.collider.gameObject.name );
        //hasHit = true;
        //rb.velocity = Vector2.zero;
        //rb.isKinematic = true;
        
        //if(collision.collider.gameObject.tag == "plus")
        //{
        //    CountDownTimer.countDownTimerObj.updateTime();
        //    Destroy(collision.gameObject);
        //}
        if(collision.gameObject.name == "Terrains"){
            shoot.readyToShoot = true;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.name == "RightWall"){
            shoot.readyToShoot = true;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.name == "LeftWall"){
            shoot.readyToShoot = true;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.name == "BottomWall"){
            shoot.readyToShoot = true;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "destroyArrow"){
            shoot.readyToShoot = true;
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "bomb"){
            shoot.readyToShoot = true;
            Destroy(this.gameObject);
        }
        //Debug.Log(ScoreManager.sm.getCurrentPoint());
        //Destroy(this.gameObject);
    }
}
