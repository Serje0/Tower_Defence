using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [HideInInspector] public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;

    /*public PathCreator pathCreator; //= GameObject.Find("PathWay").GetComponent<PathCreator>();
    private float distanceTravelled;*/

    public float speed = 1.0f;

    private void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }

    private void Update()
    {
        /*distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);*/

        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;

                /*//Vector3 nextPosition = waypoints[currentWaypoint + 1].transform.position;
                Debug.Log(gameObject.transform.position.x.Equals(waypoints[currentWaypoint + 1].transform.position.x));
                Debug.Log(gameObject.transform.position.x);
                Debug.Log(waypoints[currentWaypoint + 1].transform.position.x);
                if (gameObject.transform.position.x.Equals(waypoints[currentWaypoint + 1].transform.position.x))
                {
                    if ((gameObject.transform.position.x - waypoints[currentWaypoint + 1].transform.position.x) > 0)
                    {
                        //gameObject.transform.rotation = Quaternion.AngleAxis(0, 0, gameObject.transform.rotation.z + 90);
                        gameObject.transform.Rotate(0,0, gameObject.transform.rotation.z - 90);
                    }
                    else
                    {
                        //gameObject.transform.rotation = Quaternion.AngleAxis(0, 0, gameObject.transform.rotation.z + 270);
                        gameObject.transform.Rotate(0,0, gameObject.transform.rotation.z + 90 );
                    }
                }
                else
                {
                    if ((gameObject.transform.position.y - waypoints[currentWaypoint + 1].transform.position.y) > 0)
                    {
                        //gameObject.transform.rotation = Quaternion.AngleAxis(0, 0, gameObject.transform.rotation.z + 90);
                        gameObject.transform.Rotate(0,0, gameObject.transform.rotation.z - 90);
                    }
                    else
                    {
                        //gameObject.transform.rotation = Quaternion.AngleAxis(0, 0, gameObject.transform.rotation.z + 270);
                        gameObject.transform.Rotate(0,0, gameObject.transform.rotation.z + 90 );
                    }
                }*/
                RotateMove();
            }
            else
            {
                Destroy(gameObject);

                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            }
        }
    }

    void RotateMove()
    {
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        
        GameObject enemy = this.transform.gameObject;
        enemy.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
}
