using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] letterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject go = Instantiate(letterPrefab[Random.Range(0, 3)], transform.position, transform.rotation);
        go.SetActive(true);
    }
}
