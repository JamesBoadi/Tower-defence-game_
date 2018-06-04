using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoubleCannon : MonoBehaviour
{
    private Transform target;
    private float speed = 3f;

    private GameObject bullet1;
    private GameObject bullet2;
    private float LoadBullet = 0.8f;
    private float LoadBullet2 = 1f;
    public bool shootTarget;
    private float timeVariable;
    private float timeVariable2;
    List<GameObject> enemiesInRange = new List<GameObject>();

    [SerializeField]
    public GameObject emitter;
    public GameObject firstBullet;
    public GameObject secondBullet;

    void Start()
    {
        shootTarget = false;
        InvokeRepeating("SelectTarget", 0f, 1.2f);  // Call function SelectTarget every 1.2 seconds

    }
    

    void OnTriggerEnter2D(Collider2D DoubleCannonTarget) // Track targets in range
    {
        shootTarget = true;

        if (DoubleCannonTarget.gameObject.tag == "Enemy")
        {
            target = DoubleCannonTarget.transform;
            enemiesInRange.Add(DoubleCannonTarget.gameObject);
        }
    }
    void Update()
    {
        if (target == null) // do nothing if target is null
        { return; }

        if (enemiesInRange.Count != 0) // Shoot and rotate while the list is not empty
        {
            loadBullet();
            RotateTurret();
        }
        if (enemiesInRange.Count == 0 || shootTarget == false) // If the list is empty or no targets are in range, do nothing
        {

            return;
        }
    }
    void OnTriggerExit2D(Collider2D DoubleCannonTarget)
    {
        if (DoubleCannonTarget.gameObject.tag == "Enemy")
        {
            enemiesInRange.Remove(DoubleCannonTarget.gameObject);

        }
        shootTarget = false;
    }
    void loadBullet()
    {
        var x = emitter.transform.position.x;
        var y = emitter.transform.position.y;

        if (Time.time >= timeVariable && bullet1 == null)
        {
            bullet1 = (GameObject)Instantiate(firstBullet, new Vector3(x -0.4f,y  + 0.9f, 0), emitter.transform.rotation); // load bullet1
            
            Bulletone temp = bullet1.GetComponent<Bulletone>(); // get the target of bullet 1
            temp.target = target.gameObject;
            timeVariable = Time.time + LoadBullet; // Load bullet1 every few seconds
        }
        if (Time.time >= timeVariable2 && bullet2 == null)
        {
            bullet2 = (GameObject)Instantiate(secondBullet, new Vector3(x - 0.22f, y + 0.9f, 0), emitter.transform.rotation); // load bullet2
            Bullettwo temp2 = bullet2.GetComponent<Bullettwo>();
            temp2.target2 = target.gameObject;  // get the target of bullet 2
            timeVariable2 = Time.time + LoadBullet2; // load bullet 2 every few seconds
        }
        if (bullet1 == null)
        {
            GameObject.Destroy(bullet1);
        }
        if (bullet2 == null)
        {
            GameObject.Destroy(bullet2);
        }
    }

    void RotateTurret()
    {
        float time = Time.deltaTime;
        Vector3 direction = target.position - transform.position; // Get the direction of the turret
        float angle = Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI; // convert angle to degrees
        Quaternion rotate = Quaternion.Euler(0, 0, -angle); // rotate turret
        transform.rotation = Quaternion.RotateTowards(rotate, target.rotation, time * speed);
    }

    private void SelectTarget()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy"); // Select the target
        float shortestdistance = Mathf.Infinity; // Set distance to infinity
        GameObject nearest = null; // Target does not yet exist
        foreach (GameObject enemies in Enemy) // Iterate through each item in Enemy array
        {
            float Distance = Vector3.Distance(transform.position, enemies.transform.position); // Distance to target
           
            if (Distance <= shortestdistance) // If distance of enemy is less than the currently calculated distance, make this the target
            {
                Distance = shortestdistance;
                nearest = enemies.gameObject;
            }
            if (nearest != null)
            {
                target = nearest.transform;

            }
           
        }
    }
}
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*void load()
    {
        if (Time.time >= timestamp)
        {
            bullet1 = (GameObject)Instantiate(bullet1_, emitter.transform.position, emitter.transform.rotation);
            Collsion1 temp = bullet1.GetComponent<Collsion1>();
            temp.target = target.gameObject;
            timestamp = Time.time + loadbullet1;
        }
     /*  if (Time.time >= timestamp2)
        {
            bullet2 = (GameObject)Instantiate(bullet2_,emitter.transform.position , emitter.transform.rotation);
            Collision2 temp2 = bullet2.GetComponent<Collision2>();
            temp2.target2 = target.gameObject;
            timestamp = Time.time + loadbullet2;
        } 
 */
    