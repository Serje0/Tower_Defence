using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTower : MonoBehaviour
{
    public List<GameObject> enemiesInRange;
    private EnemyKill del;

    private float lastShootTime;
    private TowerData towerData;
    public GameObject pointShoot;

    void Start()
    {
        enemiesInRange = new List<GameObject>();
        lastShootTime = Time.time;
        towerData = gameObject.GetComponentInChildren<TowerData>();
    }

    private void Update()
    {
        GameObject target = null;
        
        float minEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<MoveEnemy>().DistanceToGoal();
            if (distanceToGoal < minEnemyDistance)
            {
                target = enemy;
                minEnemyDistance = distanceToGoal;
            }
        }

        if (target != null)
        {
            if (Time.time - lastShootTime > towerData.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider2D>());
                lastShootTime = Time.time;
            }

            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI, new Vector3(0,0,1));
        }
    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove (enemy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            del = other.gameObject.GetComponent<EnemyKill>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
            del = other.gameObject.GetComponent<EnemyKill>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    void Shoot(Collider2D target)
    {
        GameObject bulletPrefab = towerData.CurrentLevel.bullet;

        Vector3 startPosition = pointShoot.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        GameObject newBullet = (GameObject) Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        newBullet.transform.rotation = Quaternion.AngleAxis((Mathf.Atan2(startPosition.y - targetPosition.y, startPosition.x - targetPosition.x) * 180 / Mathf.PI) + 90, new Vector3(0,0,1));
        Bullet bullet = newBullet.GetComponent<Bullet>();
        bullet.traget = target.gameObject;
        bullet.startPosition = startPosition;
        bullet.tragetPosition = targetPosition;
        
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
    }
}
