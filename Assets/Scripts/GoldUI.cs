using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public Text goldText;
    private int gold;

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldText.text = gold + "$";
        }
    }
    
    void Start()
    {
        Gold = 1000;
    }
}
