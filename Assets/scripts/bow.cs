using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    public Vector2 direction;
    public float slowedFactor = 1.5f;
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
    }

    IEnumerator faceMouse()
    {
        Vector2 startPosition = transform.right;
        transform.right = Vector2.Lerp(startPosition, direction, Time.deltaTime / slowedFactor);
        yield return null;
    }
}
