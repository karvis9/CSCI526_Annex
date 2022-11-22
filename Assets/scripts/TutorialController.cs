using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialController : MonoBehaviour
{
    public GameObject mask;
    public GameObject textbox;
    public GameObject pointer;
    public GameObject sprite;

    public HashSet<char> motionKey = new HashSet<char>();

    string visibleController = "";

    // Start is called before the first frame update
    void Start()
    {
        pointer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (visibleController.Equals(""))
        {
            GameObject player = GameObject.FindGameObjectWithTag("bow");
            if (player)
            {
                textbox.GetComponent<TMP_Text>().text = "WASD for player motion.";
                mask.transform.position = player.transform.position;
                mask.transform.localScale = new Vector3(0.1f, 0.1f, 0);

                if (motionChecker())
                {
                    visibleController = "Player";
                }
            }
        }

        else if (visibleController.Equals("Player"))
        {
            //if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                mask.SetActive(false);
                textbox.GetComponent<TMP_Text>().text = "Select upto 10 characters to spawn for shooting.";
                pointer.SetActive(true);
                visibleController = "Canvas";
                //PauseGame(3f);

                // Cleanup 
                StartCoroutine(cleanup(5));
            }
        }

        //else if (visibleController.Equals("Canvas"))
        //{
        //    if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        //    {
        //        pointer.SetActive(false);
        //        textbox.GetComponent<TMP_Text>().text = "";
        //        mask.SetActive(true);
        //        GameObject player = GameObject.FindGameObjectWithTag("Health");
        //        mask.transform.position = player.transform.position;
        //        mask.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        //        //textbox.GetComponent<TMP_Text>().text = "Life";
        //    }
        //}
    }

    public bool motionChecker()
    {
        if (Input.GetKey("w"))
        {
            motionKey.Add('w');
        }
        else if (Input.GetKey("a"))
        {
            motionKey.Add('a');
        }
        else if (Input.GetKey("s"))
        {
            motionKey.Add('s');
        }
        else if (Input.GetKey("d"))
        {
            motionKey.Add('d');
        }
        return motionKey.Count == 2;
    }

    public void PauseGame(float pauseTIme)
    {
        Debug.Log("Inside PauseGame()");
        Time.timeScale = 0f;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTIme;
        while (Time.realtimeSinceStartup < pauseEndTime) ;
        Time.timeScale = 1f;
        Debug.Log("Done with my pause");
    }
 
    IEnumerator cleanup(int secs)
    {
        yield return new WaitForSeconds(secs);
        sprite.SetActive(false);
        textbox.GetComponent<TMP_Text>().text = "";
        pointer.SetActive(false);
    }
}
