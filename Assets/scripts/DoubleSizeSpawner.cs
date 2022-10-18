using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSizeSpawner : MonoBehaviour
{
    // [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private bool random;
    // public int count = 4;

    public GameObject prefab;
    //public List<char> spawnList;
    //public List<char> duplicateCharList;

    //public HashSet<char> actualSet;
    //public HashSet<char> duplicateSet;
    public int count;
    public static int totalCharsEverySec = 2;
    public static int seconds = 0;

    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
    //     for (int y=0; y<count; ++y)
    //    {
    //        for (int x=0; x<count; ++x)
    //        {
    //            Instantiate(prefab, new Vector3(x,y,0), Quaternion.identity);
    //        }
    //    }       
        // float x = Random.Range(-8,8);
        // float y = Random.Range(-4,4);
        // Instantiate(prefab, new Vector2(x,y), Quaternion.identity);
        InvokeRepeating("SpawnBonusTime", 0.0f, 50f);
    }

    void Initialize()
    {

    }

    // public void onSpawnPrefab()
    // {
    //     if(random)
    //     {
    //         float x = Random.Range(-8,8);
    //         float y = Random.Range(-4,4);
    //         Instantiate(prefab,new Vector2(x,y), Quaternion.identity);
    //     }
    //     else
    //     {
    //         Instantiate(prefab,spawnPosition, Quaternion.identity);
    //     }
    // }

    void SpawnBonusTime() {
        float x = Random.Range(-4, 6);
        float y = Random.Range(-2, 3);
        Vector2 pos = new Vector2(x, y);
        GameObject go = Instantiate(prefab, pos, transform.rotation);
        go.SetActive(true);
    }
}

