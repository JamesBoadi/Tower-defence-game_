using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleTurret : MonoBehaviour {

    private Transform target;
    private float speed = 5f;
  
    private GameObject missleClone;
    public bool shootTarget;
    private float loadMissle_ = 1.5f;
    private float timeVariable;
    List<GameObject> enemiesInRange = new List<GameObject>();

    [SerializeField]
    public GameObject emitter;
    public GameObject missle;
    public float range = 1f;

    void Start()
    {
        shootTarget = false;
        InvokeRepeating("UpdateTarget", 0f, 1.2f); // Call update target every 1.2 seconds

    }
    void OnTriggerEnter2D(Collider2D missleTarget) // if target is within the missle launcher range, add it to the list
    {
        shootTarget = true;
    
        if (missleTarget.gameObject.tag == "Enemy")
        {
            enemiesInRange.Add(missleTarget.gameObject);
        }
    }
    void Update()
    {
        if (target == null) // do nothing if target is null
        {
            return;
        }

        if (enemiesInRange.Count != 0 ) // If the list is not empty, shoot targets
        {
            if (target != null && shootTarget != false )
            {
                loadMissle();
                RotateTurret();
            }
        }
        if (enemiesInRange.Count == 0 || shootTarget == false)
        {
            return;
        }

        Debug.Log(enemiesInRange.Count);
    }
    void OnTriggerExit2D(Collider2D missleTarget) // If the target is no longer in the missle launcher range, remove it from the list
    {
     
        if (missleTarget.gameObject.tag == "Enemy")
        {
            shootTarget = false;

            if (missleTarget.gameObject == null)
            {
            
                enemiesInRange.Remove(missleTarget.gameObject);
            
            
            }
                


            Debug.Log(enemiesInRange.Count);
        }
       
    }
    void loadMissle()
    {
        if (Time.time >= timeVariable && target != null) // if the the current time is greater than the time to load missle 
        {
            missleClone = (GameObject)Instantiate(missle, emitter.transform.position, emitter.transform.rotation);
            FiredMissle temp = missleClone.GetComponent<FiredMissle>();
            temp.target = target.gameObject;
            timeVariable = Time.time + loadMissle_;
        }
    }
  
    void RotateTurret()
    {
       float time = Time.deltaTime;
       Vector3 direction = target.position - transform.position; // Get the direction of the target
       float angle = Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI; // Convert angle to degrees
       Quaternion rotate = Quaternion.Euler(0, 0, -angle);
       transform.rotation = Quaternion.RotateTowards(rotate, target.rotation, time * speed); // Rotate the turret 
    }

    private void UpdateTarget()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy"); // potential flaw
        float shortestdistance = Mathf.Infinity;
        GameObject nearest = null; // nearest enemy is null until further notice
        foreach (GameObject enemies in Enemy)
        {
            float Distance = Vector3.Distance(transform.position, enemies.transform.position);

            if (Distance <= shortestdistance) // If distance is less than shortest distance
            {
                Distance = shortestdistance;  // Nearest enemy equal to current gameobject
                nearest = enemies.gameObject;
            }
            if (nearest != null) // target made the nearest gameobject
            {
                target = nearest.transform;

            }
        }
    }


}
