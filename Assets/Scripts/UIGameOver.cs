using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreGameOverText;
    ScoreKeeper scoreKeeper;
    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start() 
    {
        scoreGameOverText.text = "You Score:\n" + scoreKeeper.GetScore();
    }
}
