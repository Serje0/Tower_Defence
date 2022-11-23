using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject tower;
    private GoldUI UI;
    public int numberTower = -1;

    private Shop shop;

    public bool CanPlaseTower()
    {
        int cost = towerPrefab.GetComponent<TowerData>().levels[0].cost;
        return tower == null && UI.Gold >= cost;
    }

    private void OnMouseUp()
    {
        if (shop.ShopUI.active == false && shop.upgradeTowers[0].active == false &&
            shop.upgradeTowers[1].active == false)
        {
            if (tower == null)
            {
                shop.OpenShop(this.gameObject.GetComponent<PlaceTower>());
            }
            else if (tower != null && numberTower != -1)
            {
                shop.OpenUpgradeShop(this.gameObject.GetComponent<PlaceTower>());
            }
        }
    }

    public void CreateTower()
    {
        tower = (GameObject) Instantiate(towerPrefab, transform.position, Quaternion.identity);
        switch (towerPrefab.name)
        {
            case "Tower_1":
                numberTower = 1;
                break;
            case "Tower_2":
                numberTower = 2;
                break;
        }
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        UI.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
    }
    
    public void UpgradeTower()
    {
        tower.GetComponent<TowerData>().IncreaseLevel();
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        UI.Gold -= tower.GetComponent<TowerData>().CurrentLevel.cost;
    }

    public bool CanUpgradeTower()
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
        shop = GameObject.Find("Shop").GetComponent<Shop>();
    }
}
