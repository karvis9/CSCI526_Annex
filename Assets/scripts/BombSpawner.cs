using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BombSpawner : MonoBehaviour
{
    //[SerializeField] GameObject[] letterPrefab;
    // public List<GameObject> letterPrefab; /*** Extend this list to add letters ***/
    public GameObject bombPrefab;
    //public List<char> spawnList;
    //public List<char> duplicateCharList;

    //public HashSet<char> actualSet;
    //public HashSet<char> duplicateSet;
    public int count;
    public static int totalCharsEverySec = 2;
    public static int seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBonusTime", 0.0f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize ()
    {
        /*
        spawnList = new List<char>();
        duplicateCharList = new List<char>();

        actualSet = new HashSet<char>();
        duplicateSet = new HashSet<char>();
        int word_len = WordBlanks.wb.word.Length;

        for (int i = 0; i < word_len; i++) {
            spawnList.Add (WordBlanks.wb.word[i]);
            actualSet.Add (WordBlanks.wb.word[i]);
            //Debug.Log ("letter " + WordBlanks.wb.word[i]);
        }

        while (duplicateSet.Count < word_len) {
            int random_num = UnityEngine.Random.Range(0, 26);
            char alphabet = (char)((int) 'a' + random_num);

            if (!actualSet.Contains (alphabet)) {
                duplicateSet.Add (alphabet);
                duplicateCharList.Add (alphabet);
            }
        }
        */
    }



    void SpawnBonusTime() {
        float x = Random.Range(-4, 6);
        float y = Random.Range(-2, 3);
        Vector2 pos = new Vector3(x, y);
        GameObject go = Instantiate(bombPrefab, pos, transform.rotation);
        go.SetActive(true);
    }

}
