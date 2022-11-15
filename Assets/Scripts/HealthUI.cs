using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthUI;
    private int health;

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
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        healthUI = gameObject.GetComponent<Slider>();
        Health = (int) healthUI.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
