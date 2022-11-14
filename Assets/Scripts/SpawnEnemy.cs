using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;
    //public GameObject testEnemyPrefab;

    public Wave[] waves;
    public int timeBetweenWave = 5;

    private WaveUI waveUI;
    private GoldUI goldUI;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;

    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public float spawnInterval = 1;
        public int maxEnemies = 20;
    }
    
    void Start()
    {
        //Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;
        lastSpawnTime = Time.time;
        waveUI = GameObject.Find("Wave").GetComponent<WaveUI>();
        goldUI = GameObject.Find("Gold").GetComponent<GoldUI>();
    }
    
    void Update()
    {
        int currentWave = waveUI.Wave;
        if (currentWave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWave) || 
                 timeInterval > spawnInterval) &&
                 enemiesSpawned < waves[currentWave].maxEnemies)
            {
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                enemiesSpawned++;
            }

            if (enemiesSpawned == waves[currentWave].maxEnemies && GameObject.FindWithTag("Enemy") == null)
            {
                waveUI.Wave++;
                goldUI.Gold = Mathf.RoundToInt(goldUI.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
        }
    }
}
