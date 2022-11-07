using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionBubble : MonoBehaviour
{
    public static OptionBubble oB;
    public static int currentLimit = 10;
    public static int currentSelected = 0; 
    public static bool selecting = false; 
    private static HashSet<string> selectedList;
    private Button myButton;
    private string myChar;
    // Start is called before the first frame update
    void Start()
    {
        oB = this;
        selectedList = new HashSet<string>();
        myButton = GetComponent<Button>();
        myChar = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        // if (selectedList.Contains(myChar)) {
        //     numbers.Remove(0);
        // }   
    }

    public void StartSelecting(){
        selecting = true;
    }
    public void AddCharacters(string ch){
        if(selectedList.Count>9)
            return;
        //Debug.Log(ch);
        if(!selecting)
            return;
        myButton.interactable = false;
        selectedList.Add(ch);
    }

    public void Submit(){
        Debug.Log("Submitted");
        selecting = false;
        foreach (object o in selectedList){
            Debug.Log(o);
        }
        selectedList.Clear();
        //List<string> spawnList= selectedList.ToList();
        //call the letter spawner manager to spawn the characters
        //LSM.spawnCharacters(selectedList);
    }
}
