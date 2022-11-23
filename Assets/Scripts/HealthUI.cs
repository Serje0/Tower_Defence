using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthUI;
    private int health;
    private bool gameOver = false;
    public GameObject gameOverUI;
    private ScoreUI scoreUI;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            healthUI.value = value;
            
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                gameOverUI.SetActive(true);
                PlayerPrefs.SetInt("lastScore", scoreUI.Score);
                if (PlayerPrefs.GetInt("record") <= scoreUI.Score)
                {
                    PlayerPrefs.SetInt("record", scoreUI.Score);
                }
                Time.timeScale = 0;
            }
        }
    }
    
    void Start()
    {
        GameObject score = GameObject.Find("Score");
        scoreUI = score.GetComponent<ScoreUI>();
        healthUI = gameObject.GetComponent<Slider>();
        Health = (int) healthUI.value;
    }
}
