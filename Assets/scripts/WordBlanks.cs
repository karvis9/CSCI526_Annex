using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class WordBlanks : MonoBehaviour
{
    public static WordBlanks wb;

    public string[] Words = { "abruptly", "absurd", "luxury", "funny", "zombie" };

    public List<TMP_Text> letterList = new List<TMP_Text>();
    public GameObject textPrefab;

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

        word = Words[index];
        Debug.Log("Selected word " + word.ToString());

        char[] tokens = word.ToCharArray();

        foreach (char letter in tokens)
        {
            GameObject temp = Instantiate(textPrefab, letterHolder, false);
            letterList.Add(temp.GetComponent<TMP_Text>());
        }
    }

    public void TargetHit()
    {
        int index = Random.Range(0, word.Length);

        letterList[index].text = word[index].ToString().ToUpper();
    }

    public void onReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
