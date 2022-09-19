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

    //private string[] Words = {"ababaa", "aaaaaa"};// Testing Words
    public string[] Words = { "abruptly", "absurd", "character", "broadcast", "zombie"};

    public List<TMP_Text> letterList = new List<TMP_Text>();
    public GameObject textPrefab;
    public List<bool> masked = new List<bool>();
    public int maskedCnt;

    // Layout
    public Transform letterHolder;
    public string word;

    // Start is called before the first frame update
    void Start()
    {
        wb = this;
        Initialize();
        //StartCoroutine(Upload());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Initialize()
    {
        int index = Random.Range(0, Words.Length);

        word = Words[index].ToLower();
        Debug.Log("Selected word " + word.ToString());

        char[] tokens = word.ToCharArray();

        foreach (char letter in tokens)
        {
            GameObject temp = Instantiate(textPrefab, letterHolder, false);
            letterList.Add(temp.GetComponent<TMP_Text>());
            masked.Add(true);
        }
        maskedCnt = masked.Count;
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
            ScoreManager.sm.increasePoint();
            if (maskedCnt == 0)
            {
                GameOverScreen.gm.EndGame(ScoreManager.sm.getFinalScore(), true, word);
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
            Debug.Log("All " + c + "'s are revealed!");
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


    public void onReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
