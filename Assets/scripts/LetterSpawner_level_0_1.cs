using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LetterSpawner_level_0_1 : MonoBehaviour
{
    //[SerializeField] GameObject[] letterPrefab;
    // public List<GameObject> letterPrefab; /*** Extend this list to add letters ***/
    public GameObject bubblePrefab;
    //public List<char> spawnList;
    //public List<char> duplicateCharList;

    //public HashSet<char> actualSet;
    //public HashSet<char> duplicateSet;
    public int count;
    public static int totalCharsEverySec = 3;
    public static int seconds = 0;

    // Start is called before the first frame update
    void Start()
    {

        count = 0;
        InvokeRepeating("PopSpawn", 0.0f, 4f);
        //InvokeRepeating("SpawnBonusTime", 0.0f, 20f);
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
        GameObject go = Instantiate(bubblePrefab, transform.position, transform.rotation);
        go.SetActive(true);
        GameObject child = go.transform.GetChild(0).gameObject;
        TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
        textmeshPro.text = "+5";
    }

    //pops an character from list and spawns it
    void PopSpawn() 
    {

        if (count == 0) {
            Initialize ();
        }

        // randomly decide no of actual chars to spwan [1, totalCharsEverySec)
        int no_actual = UnityEngine.Random.Range(1, totalCharsEverySec);
        //int word_len = WordBlanks.wb.word.Length;

        List<char> remainList = WordBlanks.wb.getRemain();
        List<char> notRemain = new List<char>();

        for(int i = 'a'; i <= 'z'; i++) {
            bool remain = false;
            for(int j = 0; j < remainList.Count; j++) {
                if(remainList[j] == i) {
                    remain = true;
                    break;
                }
            }
            if(!remain) {
                notRemain.Add((char) i);
            }
        }

        // spawn the actual chars based on above random number
        for (int i = 0; i < no_actual; i++) {

            //int idx = UnityEngine.Random.Range(0, word_len);
            int idx = UnityEngine.Random.Range(0, remainList.Count);
            //char alphabet = spawnList[idx];
            char alphabet = remainList[idx];
            int prefab_index = (int) alphabet - (int) 'a';
            
            //GameObject go = Instantiate(letterPrefab[prefab_index], transform.position, transform.rotation);
            GameObject go = Instantiate(bubblePrefab, transform.position, transform.rotation);
            go.SetActive(true);
            GameObject child = go.transform.GetChild(0).gameObject;
            TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
            textmeshPro.text = alphabet.ToString();
        }

        /*if(seconds >= 20)
        {
            GameObject go = Instantiate(bubblePrefab, transform.position, transform.rotation);
            go.SetActive(true);
            GameObject child = go.transform.GetChild(0).gameObject;
            TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
            textmeshPro.text = "+5";
            seconds = 0;
        } else
        {
            seconds += 2;
        }*/
    }
}
