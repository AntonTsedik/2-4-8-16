using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{ 
    TextMeshProUGUI scoreText;
    int currentScore;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void addScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }
}
