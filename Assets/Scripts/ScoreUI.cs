using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public Text[] scoreGameOver;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = "Очки: " + score;
            for (int i = 0; i < scoreGameOver.Length; i++)
            {
                scoreGameOver[i].text = "Вы набрали " + score + " очков";
            }
        }
    }
    
    void Start()
    {
        Score = 0;
    }
}
