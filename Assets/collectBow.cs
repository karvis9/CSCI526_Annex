using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectBow : MonoBehaviour
{
    public GameObject player;
    bow b;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(player);
        b = player.GetComponentInChildren<bow>();
        Debug.Log(b);
        b.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            b.gameObject.SetActive(true);
        }
    }
}
