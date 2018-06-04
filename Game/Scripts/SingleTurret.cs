using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTurret : MonoBehaviour
{
    private Transform target;
    private float range = 1.5f;
    private float speed = 5f;

    private GameObject singleBulletclone;
    public bool shootTarget;
    private float loadsingleBullet = 0.6f;
    private float timeVariable;
    List<GameObject> enemiesInRange_ = new List<GameObject>();

    [SerializeField]
    public GameObject emitter;
    public GameObject singleBullet_;

    void Start()
    {
        shootTarget = false;
        InvokeRepeating("UpdateTarget", 0f, 1.2f); // Call update target every 1.2 seconds
    }
    void OnTriggerEnter2D(Collider2D SingleCannonTarget) // While the target is near the turret, add it to the list
    {
        shootTarget = true;

        if (SingleCannonTarget.gameObject.tag == "Enemy")
        {
            target = SingleCannonTarget.transform;
            enemiesInRange_.Add(SingleCannonTarget.gameObject);
        }
    }
    void Update()
    {
        if (target == null) // do nothing if target is null
        { return; }

        if (enemiesInRange_.Count != 0) // If the list is not empty, shoot enemies
        {
            loadSingleBullet();
            RotateTurret();
        }
        if (enemiesInRange_.Count == 0 || shootTarget == false)
        {
            return;
        }
    }
    void OnTriggerExit2D(Collider2D SingleCannonTarget)// If the target is no longer near the turret, remove the enemy from the list
    {
        if (SingleCannonTarget.gameObject.tag == "Enemy")
        {
            enemiesInRange_.Remove(SingleCannonTarget.gameObject);
        }
        shootTarget = false;
    }
    void loadSingleBullet()
    {
        if (Time.time >= timeVariable)
        {
            singleBulletclone = (GameObject)Instantiate(singleBullet_, emitter.transform.position, emitter.transform.rotation); 
            // instantiate single bullet
            SingleBullet_ temp = singleBulletclone.GetComponent<SingleBullet_>(); // Get the target of the bullet
            temp.target = target.gameObject;
            timeVariable = Time.time + loadsingleBullet; // load bullet every few seconds
        }
        if (target == null)
        {
            GameObject.Destroy(singleBullet_);
        }
    }
    
    void RotateTurret()
    {
        float time = Time.deltaTime;
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI;
        Quaternion rotate = Quaternion.Euler(0, 0, -angle); // reference this in document
        transform.rotation = Quaternion.RotateTowards(rotate, target.rotation, time * speed);
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































