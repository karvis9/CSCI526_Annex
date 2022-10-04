using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager analyticsManager;
    private static string _url;
    private static string _sessionID;
    private int previous_charArrowCount = 0;

    private void Awake()
    {
        analyticsManager = this;
        _url = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf5HiL3ahuH4Opia2ssXz4uSGRPAB1V_FE0xFkqn07WIFaWLw/formResponse";
        
        Guid guid = Guid.NewGuid();
        _sessionID = guid.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        SendEvent("Game Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendEvent(string eventType)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.880690018", _sessionID);
        form.AddField("entry.1107566471", WordBlanks.category);

        if (eventType.Equals("Char Revealed"))
        {
            eventType = eventType + " " + (WordBlanks.wb.word.Length - WordBlanks.wb.maskedCnt);
            form.AddField("entry.890767811", WordBlanks.wb.getWord().Length);
            form.AddField("entry.19206144", ScoreManager.sm.getFinalScore());
            form.AddField("entry.1514343154", CountDownTimer.countDownTimerObj.getTimeLeft());
            form.AddField("entry.1890577055", shoot.shootController.getArrowsCount() - previous_charArrowCount);
            previous_charArrowCount = shoot.shootController.getArrowsCount();
        }
        else if (!eventType.Equals("Game Start"))
        {
            form.AddField("entry.890767811", WordBlanks.wb.getWord().Length);
            form.AddField("entry.19206144", ScoreManager.sm.getFinalScore());
            form.AddField("entry.1514343154", CountDownTimer.countDownTimerObj.getTimeLeft());
            form.AddField("entry.1890577055", shoot.shootController.getArrowsCount());
        }

        form.AddField("entry.1308275481", eventType);

        StartCoroutine(SendData(form));
    }

    IEnumerator SendData(WWWForm form)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(_url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Event reported");
            }
        }
    }
}
