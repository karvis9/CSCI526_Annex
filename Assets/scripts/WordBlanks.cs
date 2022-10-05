using System.Collections;
using System.Collections.Generic;
using System;   
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;

public class WordBlanks : MonoBehaviour
{
    public static WordBlanks wb;

    private static string[] movies = {"avengers", "titanic", "zodiac", "godzilla", "deadpool", "scarface", "saw"};

    private static string[] fruits = {"apple", "grapes", "orange", "pear", "mango", "berry", "kiwi", "banana", ""};

    private static string[] places = {"california", "texas", "india", "canada", "ethiopia", "taiwan", "london"};

    private static string[] animals = {"cat", "dog", "frog", "cheetah", "horse", "tiger"};

    Dictionary<string, string[]> categoryWords = new Dictionary<string, string[]>() {
        {"Movies", movies},
        {"Fruits", fruits},
        {"Places", places},
        {"Animals", animals}
    };

    public static string category;

    public string[] Words;

    public List<TMP_Text> letterList = new List<TMP_Text>();
    public GameObject textPrefab;
    public List<bool> masked = new List<bool>();
    public int maskedCnt;

    // Layout
    public Transform letterHolder;
    public string word;
    private List<GameObject> letterObjectList;

    // Start is called before the first frame update
    void Start()
    {
        wb = this;
        string[] testWords = { "TEST" };
        Words = testWords;
        letterObjectList = new List<GameObject>();
        Initialize();
        //StartCoroutine(Upload());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void callback(string category) {
        Debug.Log("Entered the callback");
        WordBlanks.category = category;
    }

    public void Initialize()
    {
        foreach (GameObject letter in letterObjectList) {
            Destroy(letter);
        }

        letterObjectList.Clear();
        letterList.Clear();
        masked.Clear();
        string[] words = categoryWords[category];
        int index = Random.Range(0, words.Length);

        word = words[index].ToLower();
        Debug.Log("Selected word " + word.ToString() + " from category " + category);

        char[] tokens = word.ToCharArray();

        foreach (char letter in tokens)
        {
            GameObject go = Instantiate(textPrefab, letterHolder, false);
            letterObjectList.Add(go);
            letterList.Add(go.GetComponent<TMP_Text>());
            masked.Add(true);
        }
        maskedCnt = masked.Count;
    }

    IEnumerator waiter(int index){
            Vector3 vector = letterList[index].transform.localScale;
            letterList[index].transform.localScale = new Vector3(2.8f, 2f, 2f);
            yield return new WaitForSeconds(1);
            letterList[index].transform.localScale = vector;
    }
    
    private void _reveal_index(int index) {
        if(!masked[index]) {
            Debug.Log("This letter is already revealed");
            return;
        }
        else {
            maskedCnt--;
            masked[index] = false;
            letterList[index].text = word[index].ToString().ToUpper();
            // letterList[index].transform.localScale = ;
            AnalyticsManager.analyticsManager.SendEvent("Char Revealed");
            ScoreManager.sm.increasePoint();
            if (maskedCnt == 0) {
                AnalyticsManager.analyticsManager.SendEvent("Word Guessed");
                wb.Initialize();
                //GameOverScreen.gm.EndGame(ScoreManager.sm.getFinalScore(), true, word);
            }
            else
            {
                StartCoroutine(waiter(index));
            }
        }
    }

    public void TargetHit(char c) { 
        Reveal(c); //Switch between different modes of revealing
        //RevealAll(c);
        //RevealRandom();
    }

    public void RevealRandom() // If you want a random letter to show
    {
        if(maskedCnt == 0) {
            Debug.Log("All chars are revealed!");
            return;
        }
        int order = UnityEngine.Random.Range(0, maskedCnt);
        int index = 0;
        while(!masked[index]) {
            index++;
        }
        for(int i = 0; i < order; i++) {
            index++;
            while(!masked[index]) {
                index++;
                if(masked.Count <= index) {
                    Debug.Log("An error occured");
                    return;
                }
            }
        }

        _reveal_index(index);
        //letterList[index].text = word[index].ToString().ToUpper();
    }

    public void Reveal(char c) // If you want one of a certain letter to show
    {
        int cnt = 0;
        c = Char.ToLower(c);
        for(int i = 0; i < masked.Count; i++) {
            if(c == word[i] && masked[i]) {
                cnt++;
            }
        }
        if(cnt == 0) {
            //Debug.Log("All " + c + "'s are revealed!");
            return;
        }
        int order = UnityEngine.Random.Range(0, cnt);
        int index = 0;
        while(!masked[index] || c != word[index]) {
            index++;
        }
        for(int i = 0; i < order; i++) {
            index++;
            while(!masked[index] || c != word[index]) {
                index++;
                if(masked.Count <= index) {
                    Debug.Log("An error occured");
                    return;
                }
            }
        }

        _reveal_index(index);
        //letterList[index].text = word[index].ToString().ToUpper();
    }

    public void RevealAll(char c) // If you want one of a certain letter to show
    {
        c = Char.ToLower(c);
        for(int index = 0; index < masked.Count; index++) {
            if(c == word[index] && masked[index]) {
                _reveal_index(index);
            }
        }
        //letterList[index].text = word[index].ToString().ToUpper();
    }

    public List<char> getRemain() {
        List<char> remain = new List<char>();
        for(int i = 0; i < masked.Count; i++) {
            if(masked[i]) {
                remain.Add(word[i]);
            }
        }
        return remain;
    }


    public void onReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public string getWord() { return word;}
}

