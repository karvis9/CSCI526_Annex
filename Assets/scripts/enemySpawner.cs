using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public static int submit_cnt_prev;
    // Start is called before the first frame update
    void Start()
    {
        submit_cnt_prev = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((OptionBubble.submit_cnt != submit_cnt_prev) && (OptionBubble.submit_cnt==1))
        {
            submit_cnt_prev = OptionBubble.submit_cnt;
        }
        else
            return;
        int children = LetterSpawnerManager.lsm.transform.childCount;
        Debug.Log(children);
        int spawnedChildren = 0;
        List<float> x_pos_list = new List<float>();
        for (int i = 0; i < children; i++)
        {
            GameObject go = LetterSpawnerManager.lsm.transform.GetChild(i).gameObject;
            StaticLetterSpwaner other = (StaticLetterSpwaner)go.GetComponent(typeof(StaticLetterSpwaner));

            if (!other.free)
            {
                Vector2 pos = go.transform.position;
                x_pos_list.Add((float)pos.x);
                spawnedChildren += 1;
            }
        }

        x_pos_list.Sort();
        //Debug.Log(spawnedChildren);
        float enemySpawn_x1 = x_pos_list[(int)(0.25 * spawnedChildren)];
        float enemySpawn_x2 = x_pos_list[(int)(0.75 * spawnedChildren)];
        Vector3 enemySpawn_pos1 = new Vector3(enemySpawn_x1, -3, 0);
        Instantiate(enemyPrefab, enemySpawn_pos1, transform.rotation);

        //if (enemySpawn_x2 > enemySpawn_x1 + 9)
        //{
        //    Vector3 enemySpawn_pos1 = new Vector3(enemySpawn_x1, -3, 0);
        //    Instantiate(enemyPrefab, enemySpawn_pos1, transform.rotation);
        //    Vector3 enemySpawn_pos2 = new Vector3(enemySpawn_x2, -3, 0);
        //    Instantiate(enemyPrefab, enemySpawn_pos2, transform.rotation);
        //}
        //else
        //{
        //    Vector3 enemySpawn_pos2 = new Vector3(enemySpawn_x2, -3, 0);
        //    Instantiate(enemyPrefab, enemySpawn_pos2, transform.rotation);
        //}

    }
}
