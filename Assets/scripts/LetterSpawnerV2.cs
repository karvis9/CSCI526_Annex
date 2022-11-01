using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using TMPro;

public class LetterSpawnerV2 : MonoBehaviour
{
    public static LetterSpawnerV2 ls;
    public Vector2[] pos_array;
    public GameObject bubblePrefab;
    public int screen_bubble_popu_count = 9;
    public int max_bubble_popu_count = 10;
    public double probability_correct = 0.2;
    public List<int> filled_set = new List<int>();
    public List<int> free_set = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        ls = this;
        pos_array = new Vector2[16];
        pos_array[0] = new Vector2(-6f, -3f);
        pos_array[1] = new Vector2(-4f, -3f);
        pos_array[2] = new Vector2(4f, -3f);
        pos_array[3] = new Vector2(6f, -3f);
        pos_array[4] = new Vector2(-6f, 3f);
        pos_array[5] = new Vector2(-4f, 3f);
        pos_array[6] = new Vector2(4f, 3f);
        pos_array[7] = new Vector2(6f, 3f);
        pos_array[8] = new Vector2(1f, 1f);
        pos_array[9] = new Vector2(2f, 2f);
        //pos_array[10] = new Vector2(4.42f, 0.32f);
        //pos_array[11] = new Vector2(4.42f, 0.32f);
        //pos_array[12] = new Vector2(4.42f, 0.32f);
        //pos_array[13] = new Vector2(4.42f, 0.32f);
        //pos_array[14] = new Vector2(4.42f, 0.32f);
        //pos_array[15] = new Vector2(4.42f, 0.32f);
        Invoke("initBubblesOnScreen", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void initBubblesOnScreen()

    {
        int pos_idx;

        for (int i = 0; i < max_bubble_popu_count; i++)
        {
            free_set.Add(i);
        }


        int correct_count = (int)(screen_bubble_popu_count * probability_correct);

        List<char> remainList = WordBlanks.wb.getRemain();
        List<char> notRemain = new List<char>();

        for (int i = 'a'; i <= 'z'; i++)
        {
            bool remain = false;
            for (int j = 0; j < remainList.Count; j++)
            {
                if (remainList[j] == i)
                {
                    remain = true;
                    break;
                }
            }
            if (!remain)
            {
                notRemain.Add((char)i);
            }
        }

        for (int i = 0; i < screen_bubble_popu_count - correct_count; i++)
        {
            int char_idx = UnityEngine.Random.Range(0, notRemain.Count);
            //char alphabet = spawnList[idx];
            char alphabet = notRemain[char_idx];
            int prefab_index = (int)alphabet - (int)'a';

            int random_idx = Random.Range(0, free_set.Count);
            pos_idx = free_set[random_idx];
            free_set.Remove(pos_idx);
            filled_set.Add(pos_idx);
            GameObject go = Instantiate(bubblePrefab, pos_array[pos_idx], transform.rotation);
            go.SetActive(true);
            GameObject child = go.transform.GetChild(0).gameObject;
            TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
            textmeshPro.text = alphabet.ToString();
            foreach (var x in free_set)
            {
                Debug.Log("free_list");
                Debug.Log(x.ToString());
            }

        }

        for (int i = 0; i < correct_count; i++)
        {
            int char_idx = UnityEngine.Random.Range(0, remainList.Count);
            //char alphabet = spawnList[idx];
            char alphabet = remainList[char_idx];
            int prefab_index = (int)alphabet - (int)'a';

            int random_idx = Random.Range(0, free_set.Count);
            pos_idx = free_set[random_idx];
            free_set.Remove(pos_idx);
            filled_set.Add(pos_idx);
            GameObject go = Instantiate(bubblePrefab, pos_array[pos_idx], transform.rotation);
            go.SetActive(true);
            GameObject child = go.transform.GetChild(0).gameObject;
            TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
            textmeshPro.text = alphabet.ToString();

        }

    }


    public void spawnBubbles(Vector2 position)
    {

        float distance, min_distance = 1000;
        int pos_idx = 0, idx;

        for (int i = 0; i < max_bubble_popu_count; i++)
        {
            distance = Vector2.Distance(pos_array[i], position);
            if (distance < min_distance)
            {
                pos_idx = i;
                min_distance = distance;
            }
        }

        for (idx = 0; idx < max_bubble_popu_count; idx++)
        {
            if (filled_set[idx] == pos_idx)
                break;
        }

        filled_set.Remove(pos_idx);
        free_set.Add(pos_idx);

        if (screen_bubble_popu_count > max_bubble_popu_count - 3)
            return;


        int correct_count = (int)(screen_bubble_popu_count * probability_correct);

        List<char> remainList = WordBlanks.wb.getRemain();
        List<char> notRemain = new List<char>();

        for (int i = 'a'; i <= 'z'; i++)
        {
            bool remain = false;
            for (int j = 0; j < remainList.Count; j++)
            {
                if (remainList[j] == i)
                {
                    remain = true;
                    break;
                }
            }
            if (!remain)
            {
                notRemain.Add((char)i);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            int char_idx = UnityEngine.Random.Range(0, notRemain.Count);
            //char alphabet = spawnList[idx];
            char alphabet = notRemain[char_idx];
            int prefab_index = (int)alphabet - (int)'a';

            int random_idx = Random.Range(0, free_set.Count);
            pos_idx = free_set[random_idx];
            free_set.Remove(pos_idx);
            filled_set.Add(pos_idx);
            GameObject go = Instantiate(bubblePrefab, pos_array[pos_idx], transform.rotation);
            go.SetActive(true);
            GameObject child = go.transform.GetChild(0).gameObject;
            TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
            textmeshPro.text = alphabet.ToString();
        }

        for (int i = 0; i < 1; i++)
        {
            int char_idx = UnityEngine.Random.Range(0, remainList.Count);
            //char alphabet = spawnList[idx];
            char alphabet = remainList[char_idx];
            int prefab_index = (int)alphabet - (int)'a';

            int random_idx = Random.Range(0, free_set.Count);
            pos_idx = free_set[random_idx];
            free_set.Remove(pos_idx);
            filled_set.Add(pos_idx);
            GameObject go = Instantiate(bubblePrefab, pos_array[pos_idx], transform.rotation);
            go.SetActive(true);
            GameObject child = go.transform.GetChild(0).gameObject;
            TMP_Text textmeshPro = child.GetComponent<TMP_Text>();
            textmeshPro.text = alphabet.ToString();

        }
        screen_bubble_popu_count += 3;
    }
}