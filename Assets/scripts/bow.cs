using System.Collections;
using UnityEngine;

public class bow : MonoBehaviour
{
    public Vector2 direction;
    public float slowedFactor = 1f;
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
        // Bow rotation Logic
        Vector2 parentTransform = transform.parent.gameObject.transform.position;
        float factor = parentTransform.x / 8.0f; //negative or positive but between 0 & 1
        //0.14 is offset of bow
        transform.localPosition = new Vector2(-factor * 0.2f, (1 - Mathf.Abs(factor)) * 0.2f + 0.14f);
        StartCoroutine(faceMouse());
    }

    IEnumerator faceMouse()
    {
        Vector2 startPosition = transform.right;
        transform.right = Vector2.Lerp(startPosition, direction, Time.deltaTime / slowedFactor);
        yield return null;
    }
}
