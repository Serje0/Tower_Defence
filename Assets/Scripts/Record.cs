using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour
{
    private int record;
    private ScoreUI scoreUI;
    
    public Text recordText;
    public Text lastScoreText;

    void Start()
    {
        if (recordText != null && lastScoreText != null)
        {
            recordText.text = PlayerPrefs.GetInt("record").ToString();
            lastScoreText.text = PlayerPrefs.GetInt("lastScore").ToString();
        }
        else
        {
            record = PlayerPrefs.GetInt("record");
            GameObject score = GameObject.Find("Score");
            scoreUI = score.GetComponent<ScoreUI>();
        }
    }
}
