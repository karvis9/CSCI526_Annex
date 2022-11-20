using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialController : MonoBehaviour
{
    public GameObject mask;
    public GameObject textbox;

    string visibleController = "";
    // Start is called before the first frame update
    void Start()
    {

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
                visibleController = "Player";
                PauseGame(5f);
            }
        }
        else if (visibleController.Equals("Player"))
        {
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                textbox.GetComponent<TMP_Text>().text = "Select upto 10 characters to spawn for shooting.";
            }
        }
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
}
