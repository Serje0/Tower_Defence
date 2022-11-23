using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private PlaceTower placeTower;
    public GameObject ShopUI;
    public GameObject[] upgradeTowers;
    
    public GameObject notGold;
    private float lastTime;
    private float intervalTimeText = 2.5f;
    
    public void OpenShop(PlaceTower TowerMark)
    {
        ShopUI.SetActive(true);
        placeTower = TowerMark;
    }
    
    public void OpenUpgradeShop(PlaceTower TowerMark)
    {
        placeTower = TowerMark;
        if (placeTower.numberTower == 1)
        {
            upgradeTowers[0].SetActive(true);
        }
        else if (placeTower.numberTower == 2)
        {
            upgradeTowers[1].SetActive(true);
        }
    }
    
    public void Tower(GameObject Prefab)
    {
        placeTower.towerPrefab = Prefab;
        if (placeTower.CanPlaseTower())
        {
            placeTower.CreateTower();
            ShopUI.SetActive(false);
            placeTower = null;
        }
        else if (placeTower.CanUpgradeTower())
        {
            placeTower.UpgradeTower();
            for (int i = 0; i < upgradeTowers.Length; i++)
            {
                upgradeTowers[i].SetActive(false);
            }

            placeTower.numberTower = -1;
            placeTower = null;
        }
        else
        {
            lastTime = Time.time;
            notGold.SetActive(true);
        }
    }

    public void Back()
    {
        ShopUI.SetActive(false);
        for (int i = 0; i < upgradeTowers.Length; i++)
        {
            upgradeTowers[i].SetActive(false);
        }
        notGold.SetActive(false);
        placeTower = null;
    }

    private void Update()
    {
        if (Time.time > lastTime + intervalTimeText)
        {
            notGold.SetActive(false);
        }
    }
}
