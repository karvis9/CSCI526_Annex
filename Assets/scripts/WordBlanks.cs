using System.Collections;
using System.Collections.Generic;
using System;   
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using Random=UnityEngine.Random;
using System.IO;
using UnityEngine.UI;

public class WordBlanks : MonoBehaviour
{
    public static WordBlanks wb;

    private static string[] movies = {"avengers", "titanic", "zodiac", "godzilla", "deadpool", "scarface", "saw"};
    private static List<string> moviesList = new List<string>(movies);

    private static string[] fruits = {"apple", "grapes", "orange", "pear", "mango", "berry", "kiwi", "banana", "honeydew"};
    private static List<string> fruitsList = new List<string>(fruits);

    private static string[] places = {"california", "texas", "india", "canada", "ethiopia", "taiwan", "london"};
    private static List<string> placesList = new List<string>(places);

    private static string[] animals = {"cat", "dog", "frog", "cheetah", "horse", "tiger"};
    private static List<string> animalsList = new List<string>(animals);
    
    //private static string moviesFile = "Assets/wordlist/movies.txt";
    public TextAsset movieDataFile;

    //private static string fruitsFile = "Assets/wordlist/fruits.txt";
    public TextAsset fruitsDataFile;
    
    //private static string placesFile = "Assets/wordlist/places.txt";
    public TextAsset placesDataFile;
    
    //private static string animalsFile = "Assets/wordlist/Animal.txt";
    public TextAsset animalsDataFile;

    Dictionary<string, List<string>> categoryWords = new Dictionary<string, List<string>>() {
        {"Movies", moviesList},
        {"Fruits", fruitsList},
        {"Places", placesList},
        {"Animals", animalsList}
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

    public GameObject indicator;
    public GameObject redindicator;

    public AudioSource correctAudioPlayer;
    public AudioSource incorrectAudioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        char newlineChar = '\n';
        // string[] lines = File.ReadAllLines(moviesFile);
        string[] lines = movieDataFile.text.Split(newlineChar);
        foreach (string line in lines)
            moviesList.Add(line);

        // lines = File.ReadAllLines(placesFile);
        lines = placesDataFile.text.Split(newlineChar);
        foreach (string line in lines)
            placesList.Add(line);

        // lines = File.ReadAllLines(fruitsFile);
        lines = fruitsDataFile.text.Split(newlineChar);
        foreach (string line in lines)
            fruitsList.Add(line);

        // lines = File.ReadAllLines(animalsFile);
        lines = animalsDataFile.text.Split(newlineChar);
        foreach (string line in lines)
            animalsList.Add(line);

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
        if(indicator !=null)
        {
            if(indicator.GetComponent<Image>().color.a > 0)
            {
                var color = indicator.GetComponent<Image>().color;
                color.a -= 0.01f;
                indicator.GetComponent<Image>().color = color;
            }
        }
        if(redindicator !=null)
        {
            if(redindicator.GetComponent<Image>().color.a > 0)
            {
                var color = redindicator.GetComponent<Image>().color;
                color.a -= 0.01f;
                redindicator.GetComponent<Image>().color = color;
            }
        }
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
        category = PlayerPrefs.GetString("Category");
        // string[] words = categoryWords[category];
        // int index = Random.Range(0, words.Length);

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName.Equals("Level_0"))
        {
            word = "game";
        }
        else
        {
            List<string> words = categoryWords[category];
            int index = Random.Range(0, words.Count);

            word = words[index].ToLower();
        }
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
        /*Vector3 vector = letterList[index].transform.localScale;
        letterList[index].transform.localScale = new Vector3(2.8f, 2f, 2f);
        yield return new WaitForSeconds(1);
        letterList[index].transform.localScale = vector;*/

        // make it more interesting
        Vector3 baseline = letterList[index].transform.localScale;
        Vector3 highpoint = new Vector3(2.8f, 2f, 2f); // can adjust
        float totalAnimationTime = 1.0f; // can adjust
        int totalFrames = 50; // can adjust
        for(int i = 0; i < totalFrames; i++) {
            letterList[index].transform.localScale = 4 * (baseline - highpoint) * (i - totalFrames / 2) * (i - totalFrames / 2) / (totalFrames * totalFrames) + highpoint;
            yield return new WaitForSeconds(totalAnimationTime / (float) totalFrames);
        }
        letterList[index].transform.localScale = baseline;
        
    }
    public void redIndicator()
    {
        var color = redindicator.GetComponent<Image>().color;
        color.a = 0.6f;
        redindicator.GetComponent<Image>().color = color;
    }
    
    private void _reveal_index(int index) {
        var color = indicator.GetComponent<Image>().color;
        color.a = 0.6f;
        indicator.GetComponent<Image>().color = color;
        correctAudioPlayer.Play();

        // redIndicator();
        // incorrectAudioPlayer.Play();

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
                Message.msg.SendMessage("Word guessed!", Color.green, 2f);
                AnalyticsManager.analyticsManager.SendEvent("Word Guessed");
                wb.Initialize();
                ArrowIndicator.arrowIndicator.Add (10);
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

