using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Zero : MonoBehaviour
{
    public int CharsLength;
    // Start is called before the first frame update
    void Start()
    {
        //instantiate player
        //get count of bubbles to hit
        //CharsLength = GameObject.FindGameObjectsWithTag("Letter").Length;
        PlayerPrefs.DeleteKey("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Letter").Length == 0)
            // SceneChanger.sc.switchToScene("Level_1");
            SceneChanger.sc.switchToNextLevel();
    }


}
