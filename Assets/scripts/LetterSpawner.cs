using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    //[SerializeField] GameObject[] letterPrefab;
    public List<GameObject> letterPrefab; /*** Extend this list to add letters ***/
    public Queue<char> spawnList;


    // Start is called before the first frame update
    void Start()
    {
        spawnList = new Queue<char>();
        spawnList.Enqueue('A');
        spawnList.Enqueue('A');
        spawnList.Enqueue('A');
        spawnList.Enqueue('A');
        spawnList.Enqueue('A');
        spawnList.Enqueue('A');
        spawnList.Enqueue('A');
        spawnList.Enqueue('B');
        spawnList.Enqueue('B');
        spawnList.Enqueue('B');
        spawnList.Enqueue('B');
        InvokeRepeating("PopSpawn", 0.0f, 0.6f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //pops an character from list and spawns it
    void PopSpawn() 
    {
        if(spawnList.Count == 0) {
            // Randomly spawns from List
            GameObject go = Instantiate(letterPrefab[Random.Range(0, letterPrefab.Count)], transform.position, transform.rotation);
            go.SetActive(true);
        }
        else {
            GameObject go = Instantiate(letterPrefab[spawnList.Dequeue() - 'A'], transform.position, transform.rotation);
            go.SetActive(true);
        }
    }
}
