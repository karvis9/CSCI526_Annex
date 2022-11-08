using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawnerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static LetterSpawnerManager lsm;
    private void Awake()
    {
        lsm = this;
    }
    void Start()
    {
        //List<char> chars = new List<char>();
        //chars.Add('A');
        //chars.Add('B');
        //chars.Add('C');
        //spawnCharacters(chars);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCharacters(List<char> charList)
    {
        destroyCharacters();
        int children = transform.childCount;
        for (int i = 0; i < children && i < charList.Count; ++i)
        {
            Debug.Log("Chars : " + charList[i]);
            GameObject go = transform.GetChild(i).gameObject;

            StaticLetterSpwaner other = (StaticLetterSpwaner)go.GetComponent(typeof(StaticLetterSpwaner));
            other.spawnLetter(charList[i]);
        }
    }

    void destroyCharacters()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            GameObject go = transform.GetChild(i).gameObject;
            StaticLetterSpwaner other = (StaticLetterSpwaner)go.GetComponent(typeof(StaticLetterSpwaner));

            if (!other.free)
            {
                other.destroy();
            }
        }
    }

    public int getFreeLetterSpawners()
    {
        int children = transform.childCount;
        int freeChild = 0;

        for (int i = 0; i < children; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            StaticLetterSpwaner other = (StaticLetterSpwaner)go.GetComponent(typeof(StaticLetterSpwaner));
            
            if (other.free)
            {
                freeChild++;
            }
        }

        return freeChild;
    }
}
