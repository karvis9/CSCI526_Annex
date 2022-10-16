using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{

    public GameObject Animator;
    public ParticleSystem ps;
    //public ParticleSystem ps = Animator.gameObject.GetComponent<ParticleSystem>();
    public GameObject[] bubbles;
    // Start is called before the first frame update
    void Start()
    {
        ps = Animator.gameObject.GetComponent<ParticleSystem>();
        transform.position = new Vector3(Random.Range(8f, 9f), Random.Range(-2.0f, 3.5f), transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        //Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1000);
        //Debug.Log(hitColliders.Length);
        //if (collision.gameObject.name == "Arrow(Clone)")
        //{
        //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1000);
        //    Debug.Log(hitColliders.Length);
        //    foreach (var hitCollider in hitColliders)
        //    {
        //        //Debug.Log("overlap collision");
        //        if (hitCollider.name == "Letter")
        //        {
        //            Debug.Log("overlap collision");
        //            //anim.Play("BubblePop");
        //            Destroy(hitCollider.gameObject, 0.6f);

        //        }
        //        //Debug.Log(hitCollider.name);
        //    }
        //}

        if (collision.gameObject.name == "Arrow(Clone)")
        {
            AnalyticsManager.analyticsManager.SendEvent("Bomb hit");

            bubbles = GameObject.FindGameObjectsWithTag("Letter");
            //Debug.Log(bubbles.Length);
            foreach (var bubble in bubbles)
            {
                Vector2 bubble_pos = bubble.gameObject.transform.position;
                float dist = Vector2.Distance(bubble_pos, transform.position);
                if (dist < 4)
                {
                    bubble.gameObject.SetActive(false);
                }
            }
            ps.Play();
        }
        //ParticleSystem ps = Animator.gameObject.GetComponent<ParticleSystem>();
        //Debug.Log(ps);
        Destroy(this.gameObject, 0.2f);

    }
}
