using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager ht;
    public GameObject heart_health_1, heart_health_2, heart_health_3, heart_health_4, heart_health_5;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        ht = this;
        health = 5;
        heart_health_1.gameObject.SetActive(true);
        heart_health_2.gameObject.SetActive(true);
        heart_health_3.gameObject.SetActive(true);
        heart_health_4.gameObject.SetActive(true);
        heart_health_5.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (health > 5)
        {
            health = 5;
        }
        switch (health)
        {
            case 5:
                heart_health_1.gameObject.SetActive(true);
                heart_health_2.gameObject.SetActive(true);
                heart_health_3.gameObject.SetActive(true);
                heart_health_4.gameObject.SetActive(true);
                heart_health_5.gameObject.SetActive(true);
                break;
            case 4:
                heart_health_1.gameObject.SetActive(true);
                heart_health_2.gameObject.SetActive(true);
                heart_health_3.gameObject.SetActive(true);
                heart_health_4.gameObject.SetActive(true);
                heart_health_5.gameObject.SetActive(false);
                break;
            case 3:
                heart_health_1.gameObject.SetActive(true);
                heart_health_2.gameObject.SetActive(true);
                heart_health_3.gameObject.SetActive(true);
                heart_health_4.gameObject.SetActive(false);
                heart_health_5.gameObject.SetActive(false);
                break;
            case 2:
                heart_health_1.gameObject.SetActive(true);
                heart_health_2.gameObject.SetActive(true);
                heart_health_3.gameObject.SetActive(false);
                heart_health_4.gameObject.SetActive(false);
                heart_health_5.gameObject.SetActive(false);
                break;
            case 1:
                heart_health_1.gameObject.SetActive(true);
                heart_health_2.gameObject.SetActive(false);
                heart_health_3.gameObject.SetActive(false);
                heart_health_4.gameObject.SetActive(false);
                heart_health_5.gameObject.SetActive(false);
                break;
            case 0:
                heart_health_1.gameObject.SetActive(false);
                heart_health_2.gameObject.SetActive(false);
                heart_health_3.gameObject.SetActive(false);
                heart_health_4.gameObject.SetActive(false);
                heart_health_5.gameObject.SetActive(false);
                Debug.Log("End screen called");
                GameOverScreen.EndGame(ScoreManager.sm.getFinalScore(), false, WordBlanks.wb.word);
                //Time.timeScale = 0;
                break;

        }
        

    }
    public void decreaseHealth()
    {
        health = health-1;
    }
}
