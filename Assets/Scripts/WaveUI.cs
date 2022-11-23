using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text waveText;
    public Animator nextWave;
    private int wave;
    public bool gameOver = false;
    public GameObject GameWinUI;
    private ScoreUI scoreUI;

    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;

            if (!gameOver)
            {
                nextWave.SetTrigger("nextWave");

                if (wave != 0)
                {
                    scoreUI.Score += 100;
                }
            }

            waveText.text = "Волна №" + (wave + 1);
        }
    }
    
    void Start()
    {
        GameObject score = GameObject.Find("Score");
        scoreUI = score.GetComponent<ScoreUI>();
        Wave = 0;
    }
}
