using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Freeze_spawner : MonoBehaviour
{
    public GameObject freezePowerup;
    //[SerializeField] private Vector2 spawnPosition;
    //[SerializeField] private bool random;
    // public int count = 4;

    //public List<char> spawnList;
    //public List<char> duplicateCharList;

    //public HashSet<char> actualSet;
    //public HashSet<char> duplicateSet;
    //public int count;
    //public static int totalCharsEverySec = 2;
    //public static int seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Coroutine for spawning delay
        //StartCoroutine(SpawningDelay());
        InvokeRepeating("SpawnFreezePowerup", 0.0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //IEnumerator SpawningDelay()
    //{
    //    yield return new WaitForSeconds(10);
    //    SpawnFreezePowerup();

    //}


    void SpawnFreezePowerup()
    {
        float x = Random.Range(-4, 6);
        float y = Random.Range(-2, 3);
        Vector2 pos = new Vector2(x, y);
        GameObject go = Instantiate(freezePowerup, pos, transform.rotation);
        go.SetActive(true);
    }
}
