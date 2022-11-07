using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    public int Score { get => score; set => score = value; }
    static ScoreKeeper instance;
    public int GetScore()
    {
        return score;
    }
    void Awake() 
    {
        ManageSingleton();
    }
    private void ManageSingleton() 
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;   
            DontDestroyOnLoad(gameObject);
        }
    }
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
