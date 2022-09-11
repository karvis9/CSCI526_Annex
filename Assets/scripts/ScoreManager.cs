using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager sm;
    public int points = 0;
    public int maxPoints = 3;

    void Start()
    {
        sm = this;
    }
    public int getCurrentPoint(){
        return points;
    }
    public void increasePoint(){
        if(points<=maxPoints)
            points++; 
    }
}
