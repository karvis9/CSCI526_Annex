using System.Collections;
using UnityEngine;

public class bow_Level1 : MonoBehaviour
{
    public Vector2 direction;
    public float slowedFactor = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        direction = mousePos - bowPos;
        StartCoroutine(faceMouse());

        Vector3 pos = transform.position;
        //Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
        //body.AddForce(Input.GetAxis("Horizontal") * Vector3.right * 0.2f);
        //body.AddForce(Input.GetAxis("Vertical") * Vector3.up * 0.2f);
       // Debug.Log(pos.x);
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += 4f * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= 4f * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= 4f * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += 4f * Time.deltaTime;
        }

        if (pos.x > 7f) {
            pos.x = 7f;
        }
        else if(pos.x < -7f) {
            pos.x = -7f;
        }

        if(pos.y > 3f) {
            pos.y = 3f;
        }
        else if(pos.y < -3f) {
            pos.y = -3f;
        }
        transform.position = pos;
    }

    IEnumerator faceMouse()
    {
        Vector2 startPosition = transform.right;
        transform.right = Vector2.Lerp(startPosition, direction, Time.deltaTime / slowedFactor);
        yield return null;
    }
}
