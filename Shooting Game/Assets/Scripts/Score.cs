using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;
    
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    void Update()
    {

    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score; 
    }
}
