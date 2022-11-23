using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlay : MonoBehaviour
{
    public GameObject[] Maps;
    void Start()
    {
        Instantiate(Maps[Random.Range(0, Maps.Length)]);
    }
}
