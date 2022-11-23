using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public GameObject traget;
    public Vector3 startPosition;
    public Vector3 tragetPosition;

    private float distance;
    private float startTime;

    private GoldUI goldUI;
    private ScoreUI scoreUI;
    
    void Start()
    {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, tragetPosition);
        GameObject gold = GameObject.Find("Gold");
        GameObject score = GameObject.Find("Score");
        goldUI = gold.GetComponent<GoldUI>();
        scoreUI = score.GetComponent<ScoreUI>();
    }
    
    void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, tragetPosition, timeInterval * speed / distance);

        if (gameObject.transform.position.Equals(tragetPosition))
        {
            if (traget != null)
            {
                Transform healrhEnemyTransform = traget.transform.Find("HealthEnemy");
                HealthEnemy healthEnemy = healrhEnemyTransform.gameObject.GetComponent<HealthEnemy>();
                healthEnemy.currentHealth -= Mathf.Max(damage, 0);

                if (healthEnemy.currentHealth <= 0)
                {
                    scoreUI.Score += healthEnemy.scoreKill;
                    Destroy(traget);
                    AudioSource audioSource = traget.GetComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    goldUI.Gold += 50;
                }
            }
            Destroy(gameObject);
        }
    }
}
