using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
   int score;
    public int Score { get => score; set => score = value; }
    public void ModifyScore (int value) 
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
