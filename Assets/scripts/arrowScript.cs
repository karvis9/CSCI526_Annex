using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log( "Collided with : " + collision.collider.gameObject.name );
        //hasHit = true;
        //rb.velocity = Vector2.zero;
        //rb.isKinematic = true;
        if(collision.collider.gameObject.tag == "Letter"){
            //Debug.Log("Got point, reveal alphabet");
            char symbol = collision.collider.gameObject.GetComponent<Bubble>().symbol;// might fix this later
            //Debug.Log("Target Hit: " + symbol);
            WordBlanks.wb.TargetHit(symbol);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name == "Terrains"){
            Destroy(this.gameObject);
        }
        //Debug.Log(ScoreManager.sm.getCurrentPoint());
        //Destroy(this.gameObject);
    }
}
