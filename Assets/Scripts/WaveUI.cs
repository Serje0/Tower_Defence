using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text waveText;
    private int wave;

    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            waveText.text = "Волна №" + (wave + 1);
        }
    }
    
    void Start()
    {
        Wave = 0;
    }
}
