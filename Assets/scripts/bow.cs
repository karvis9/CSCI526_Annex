using System.Collections;
using UnityEngine;

public class bow : MonoBehaviour
{
    public Vector2 direction;
    public float slowedFactor = 1.2f;
    public static bow bw;
    // Start is called before the first frame update
    void Start()
    {
        bw = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        direction = mousePos - bowPos;
        StartCoroutine(faceMouse());
        //RotateHand();
    }

    void RotateHand()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }

    IEnumerator faceMouse()
    {
        Vector2 startPosition = transform.right;
        transform.right = Vector2.Lerp(startPosition, direction, Time.deltaTime / slowedFactor);
        //Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion rotation;
        //if(CharacterController2D.m_FacingRight)
        //{
        //    rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        //    transform.right = Vector2.Lerp(startPosition, direction, Time.deltaTime / slowedFactor);
        //} else
        //{
        //    rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        //    transform.right = Vector2.Lerp(startPosition, direction, Time.deltaTime / slowedFactor);
        //}
            
        //transform.rotation = rotation;
        yield return null;
    }
}
