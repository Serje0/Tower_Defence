using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject towerPerfab;
    private GameObject tower;
    private GoldUI UI;

    private bool CanPlaseTower()
    {
        int cost = towerPerfab.GetComponent<TowerData>().levels[0].cost;
        return tower == null && UI.Gold >= cost;
    }

    private void OnMouseUp()
    {
        if (CanPlaseTower())
        {
            tower = (GameObject) Instantiate(towerPerfab, transform.position, Quaternion.identity);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            UI.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
        else if (UpgradeMonster())
        {
            tower.GetComponent<TowerData>().IncreaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            UI.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
        }
    }

    private bool UpgradeMonster()
    {
        if (tower != null)
        {
            TowerData towerData = tower.GetComponent<TowerData>();
            TowerLevel nextLevel = towerData.GetNextLevel();
            int cost = nextLevel.cost;
            if (nextLevel != null && UI.Gold >= cost)
            {
                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        UI = GameObject.Find("Gold").GetComponent<GoldUI>();
    }
}
