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
    public static bool selectingState = true;
    public static int submit_cnt = 0;
    private static HashSet<string> selectedList;
    private static HashSet<string> badSet;
    public static Color disableColor;
    public static Color normalColor;
    public static Color selectedColor;
    public static ColorBlock normalStateColors;
    public static Color changeStateColor;
    private Button myButton;
    private bool buttonPressed;
    private string myChar;
    // Start is called before the first frame update
    void Start()
    {
        disableColor = Color.grey;
        normalColor = Color.white;
        selectedColor = Color.red;
        changeStateColor = Color.green;
        buttonPressed = false;
        oB = this;
        selectedList = new HashSet<string>();
        badSet = new HashSet<string>();
        myButton = GetComponent<Button>();
        myChar = this.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text.ToLower();
        submit_cnt = 0;
        normalStateColors = myButton.colors;
    }

    // Update is called once per frame
    void Update()
    {
        if(badSet.Contains(myChar)){
            myButton.interactable = false;
        }
        else{
            if(!selectingState){
                if(myChar.Equals("select")||myChar.Equals("submit")) {
                    //TurnWhite();
                    ;
                }
                else
                    TurnDisable();
            }
            else if(selectedList.Contains(myChar)){
                buttonPressed = true;
                TurnRed();
            }
            else if(myChar.Equals("select")) {
                ;
            }
            else{
                TurnWhite();
            }
        }
    }

    public int getSelectedCount(){
        return selectedList.Count;
    }

    public void SelectingPressed(){
        if(!selectingState) {
            Debug.Log("Start Selecting");
            StateTurnGreen();
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Submit";
            selectingState = true;
        }
        else {
            StateTurnBack();
            Submit();
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Select";
            selectingState = false;
        }
    }
    public void AddCharacters(string ch){    
        
        // if(!selectingState)
        //     return;
        
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
        Submit();
    }


    public static void Submit(){
        Debug.Log("submit called");
        List<char> chars = new List<char>();
        // selectingState = false;
        //call the letter spawner manager to spawn the characters

        foreach (var item in selectedList) {
            Debug.Log ("selected item " + item);
            char alphabet = item[0];
            chars.Add (alphabet);
        }

        LetterSpawnerManager.lsm.spawnCharacters(chars);
        submit_cnt += 1;
    }
    public void TurnRed()
    {
        ColorBlock colors = myButton.colors;
        colors.normalColor = selectedColor;
        colors.highlightedColor = selectedColor;
        colors.pressedColor = selectedColor;
        myButton.colors = colors;
    }

    public void StateTurnGreen()
    {
        ColorBlock colors = myButton.colors;
        colors.normalColor = changeStateColor;
        colors.highlightedColor = changeStateColor;
        colors.pressedColor = changeStateColor;
        myButton.colors = colors;
        Debug.Log("Color Green");
    }

    public void StateTurnBack()
    {
        myButton.colors = normalStateColors;
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

    public void updateBadList(string c)
    {
        selectedList.Remove(c);
        badSet.Add(c);
    }
}
