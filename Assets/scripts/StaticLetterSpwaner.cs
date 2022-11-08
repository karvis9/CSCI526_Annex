using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StaticLetterSpwaner : MonoBehaviour
{
    public GameObject bubblePrefab;

    public bool free = true;
    GameObject go;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!go)
        {
            free = true;
        }
    }

    public void spawnLetter(char letter)
    {
        Debug.Log("Spawning new character " + letter);
        go = Instantiate(bubblePrefab, transform.position, transform.rotation);
        go.SetActive(true);
        GameObject child = go.transform.GetChild(0).gameObject;
        TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
        textmeshPro.text = "" + letter;
        Debug.Log("Char :- " + textmeshPro.text);
        free = false;
    }

    public void destroy()
    {
        Destroy(go);
        free = true;
    }
}
