using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestingFinal;
public class MoveBoss : MonoBehaviour {

    

    [SerializeField]
    public float speed = 1.5f;
    public GameObject[] Waypoints_;
    public GameObject enemyPrefab_;
    public int currentwaypoint_;

    private Transform no;
    private float lastWaypointSwitchTime;
    public Vector3 startPosition_;
    public Vector3 endPosition_;
    public Vector3 currentposition;
    public float timeandspeed;

    void Start()
    {
  

        lastWaypointSwitchTime = Time.time;
        startPosition_ = Waypoints_[0].transform.position;


    }

 /* private void CalculatePath() // Calculate the shortestpath
    {
        for (int i = 0; i < Waypoints_.Length; i++)
        {
        shortestPath.Path(0,i, Waypoints_[i])

        }
        for(int a = 0: a < Waypoints_.Length; a++)
        {
           Waypoints_[a] = shortestPath.print(Waypoints_[a]);

        }
    } */

    public IEnumerator Slerp(Transform a, Quaternion endRot, float slerpTime)
    {
        {
            float currenttimeOnPath = 0; // Current time for rotation
            while (currenttimeOnPath < slerpTime)
            {
                currenttimeOnPath += Time.deltaTime; // rotate enemy over time
                transform.rotation = Quaternion.Slerp(a.rotation, endRot, currenttimeOnPath);
            }
            yield return null;
        }
    }

    void MoveEnemy()
    {
        no = transform;
        startPosition_ = Waypoints_[currentwaypoint_].transform.position; // startpositon
        endPosition_ = Waypoints_[currentwaypoint_ + 1].transform.position; // Nextposition
        Vector3 direction = startPosition_ - endPosition_;
        var distance = Vector3.Distance(startPosition_, endPosition_); // Distance to each point
        float totalTimeForPath = distance / speed; // Time to move enemy
        float currentTimeOnPath = (Time.time - lastWaypointSwitchTime);	  // Current time                                                                 
        timeandspeed = currentTimeOnPath / totalTimeForPath;  // Time converted to percentiles
        enemyPrefab_.transform.position = Vector3.Lerp(startPosition_, endPosition_, timeandspeed); // Move enemies along path
        var angle = Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI; // Converted to degrees

        if (enemyPrefab_.transform.position == endPosition_)  // If enemy is at the next position
        {
            if (currentwaypoint_ < Waypoints_.Length - 2)
            {
                currentwaypoint_++;   // Increment to next posiiton
                startPosition_ = transform.position;
                endPosition_ = Waypoints_[currentwaypoint_].transform.position;
                distance = Vector3.Distance(startPosition_, endPosition_);
                lastWaypointSwitchTime = Time.time;
                StartCoroutine(Slerp(no, Quaternion.Euler(0, 0, angle), timeandspeed));

            }
            if (enemyPrefab_.transform.position.Equals(Waypoints_[Waypoints_.Length - 1].transform.position)) // If enemy is at last waypoint
            {
                var startWave = GameObject.Find("Manager").GetComponent<WaveManager>();
                startWave.Exit(enemyPrefab_.gameObject);
                GameManager.Instance.DecreaseHealth(1);
                GameObject.Destroy(enemyPrefab_.gameObject);
            }
        }

    }

    void Update()
    {
        MoveEnemy();


    }



}
