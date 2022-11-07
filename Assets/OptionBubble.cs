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
    public static bool selectingState = false; 
    private static HashSet<string> selectedList;
    private static HashSet<string> badSet;
    public static Color disableColor;
    public static Color normalColor;
    public static Color selectedColor;
    private Button myButton;
    private bool buttonPressed;
    private string myChar;
    // Start is called before the first frame update
    void Start()
    {
        disableColor = Color.grey;
        normalColor = Color.white;
        selectedColor = Color.red;
        buttonPressed = false;
        oB = this;
        selectedList = new HashSet<string>();
        badSet = new HashSet<string>();
        myButton = GetComponent<Button>();
        myChar = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text.ToLower();
    }

    // Update is called once per frame
    void Update()
    {
        if(badSet.Contains(myChar)){
            myButton.interactable = false;
        }
        else{
            if(!selectingState){
                if(myChar.Equals("select")||myChar.Equals("submit"))
                    TurnWhite();
                else
                    TurnDisable();
            }
            else if(selectedList.Contains(myChar)){
                buttonPressed = true;
                TurnRed();
            }
            else{
                TurnWhite();
            }
        }
    }

    public int getSelectedCount(){
        return selectedList.Count;
    }

    public void StartSelecting(){
        Debug.Log("Start Selecting");
        selectingState = true;
    }
    public void AddCharacters(string ch){    
        
        if(!selectingState)
            return;
        
        if(!buttonPressed){
            if(selectedList.Count>9){
                return;
            }
            buttonPressed = true;
            selectedList.Add(myChar);
        }   
        else{
            buttonPressed = false;
            selectedList.Remove(myChar);
        }
        
    }

    public void Submit(){
        List<char> chars = new List<char>();
        selectingState = false;
        //List<string> spawnList= selectedList.ToList();
        //call the letter spawner manager to spawn the characters
        //LSM.spawnCharacters(selectedList);
    }
    public void TurnRed()
     {
         ColorBlock colors = myButton.colors;
         colors.normalColor = selectedColor;
         colors.highlightedColor = selectedColor;
         colors.pressedColor = selectedColor;
         myButton.colors = colors;
     }
     
     public void TurnWhite()
     {
         ColorBlock colors = myButton.colors;
         colors.normalColor = normalColor;
         colors.highlightedColor = normalColor;
         colors.pressedColor = normalColor;
         myButton.colors = colors;
     }
     public void TurnDisable()
     {
         ColorBlock colors = myButton.colors;
         colors.normalColor = disableColor;
         colors.highlightedColor = disableColor;
         colors.pressedColor = disableColor;
         myButton.colors = colors;
     }
}
