using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    //[SerializeField] GameObject[] letterPrefab;
    public List<GameObject> letterPrefab; /*** Extend this list to add letters ***/
    public List<char> spawnList;
    public List<char> duplicateCharList;

    public HashSet<char> actualSet;
    public HashSet<char> duplicateSet;
    public int count;
    public static int totalCharsEverySec = 2; 

    // Start is called before the first frame update
    void Start()
    {
        spawnList = new List<char>();
        duplicateCharList = new List<char> ();

        actualSet = new HashSet<char> ();
        duplicateSet = new HashSet<char> ();

        count = 0;
        InvokeRepeating("PopSpawn", 0.0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initialize ()
    {
        int word_len = WordBlanks.wb.word.Length;

        for (int i = 0; i < word_len; i++) {
            spawnList.Add (WordBlanks.wb.word[i]);
            actualSet.Add (WordBlanks.wb.word[i]);
            Debug.Log ("letter " + WordBlanks.wb.word[i]);
        }

        while (duplicateSet.Count < word_len) {
            int random_num = UnityEngine.Random.Range(0, 26);
            char alphabet = (char)((int) 'a' + random_num);

            if (!actualSet.Contains (alphabet)) {
                duplicateSet.Add (alphabet);
                duplicateCharList.Add (alphabet);
            }
        }
    }

    //pops an character from list and spawns it
    void PopSpawn() 
    {

        if (count == 0) {
            Initialize ();
        }

        // randomly decide no of actual chars to spwan
        int no_actual = UnityEngine.Random.Range(1, totalCharsEverySec);
        int word_len = WordBlanks.wb.word.Length;

        // spawn the actual chars based on above random number
        for (int i = 0; i < no_actual; i++) {

            int idx = UnityEngine.Random.Range(0, word_len);
            char alphabet = spawnList[idx];
            int prefab_index = (int) alphabet - (int) 'a';
            
            GameObject go = Instantiate(letterPrefab[prefab_index], transform.position, transform.rotation);
            go.SetActive(true);
        }

        // spawn non-actual chars based on totalCharsEverySec
        for (int i = no_actual; i < totalCharsEverySec; i++) {
            int idx = UnityEngine.Random.Range(0, word_len);
            char alphabet = duplicateCharList[idx];
            int prefab_index = (int) alphabet - (int) 'a';

            GameObject go = Instantiate(letterPrefab[prefab_index], transform.position, transform.rotation);
            go.SetActive(true);
        }
    }
}
