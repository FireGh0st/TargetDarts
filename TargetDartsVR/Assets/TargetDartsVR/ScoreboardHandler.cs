using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreboardHandler : MonoBehaviour
{
    public GameObject tmp;
    private TextMeshPro score_text;
    public bool keep_score = true;
    private int score;
    void Start()
    {
        score_text = tmp.GetComponent<TextMeshPro>();
    }

    public void AddScore(int points) 
    {
        if (keep_score)
        {
            score += points;
            score_text.text = score.ToString();
        }
    }

    public void ResetScore() 
    {
        score = 0;
        score_text.text = "0000";
    }

    
}
