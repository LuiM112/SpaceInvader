using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCapture : MonoBehaviour
{
    private int ScoreCount;
    private int hiScoreCount;
    private static int hiScoreTotal;
    public GameObject Score;
    public GameObject highScore;
    
    private void Start()
    {
        ScoreCount = 0;
        Score.GetComponent<TextMeshProUGUI>().text = ScoreCount.ToString().PadLeft(4, '0');
    }

    public void Update()
    {
        
    }

    public void UpdateScore(int points)
    {
        Score.GetComponent<TextMeshProUGUI>().text = points.ToString().PadLeft(4, '0');

        if (points > hiScoreTotal)
        {
            hiScoreTotal = points;
            highScore.GetComponent<TextMeshProUGUI>().text = hiScoreTotal.ToString().PadLeft(4, '0');
        }
    }
}
