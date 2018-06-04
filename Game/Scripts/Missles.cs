using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missles : MonoBehaviour {

    private GameObject target;
    public GameObject temp;
    public Vector3 startPosition;
    private float time;
    private float lastWaypointSwitchTime;
    public bool enable;

    [SerializeField]
    public float speed = 10;
    public int damage;
    public GameObject missle;

    void Start()
    {
        startPosition = GameObject.Find("Missletower").transform.position;
        target = GameObject.FindWithTag("Enemy");

        if (enable == true)
        {
            InvokeRepeating("mis", 0.1f, 1f);
            Debug.Log("Working?");
        }
    }

    void Update()
    {
        Get();
        Start();

       
    }
    void Get()
    {
       /* if (GameObject.Find("Missletower").GetComponent<TurretScript>().enable) // if enemy is within range
        {
            enable = true;
        }
        else
        {
            enable = false;
        } */

        // Add health, gold et
    }

    void mis()
    {
        if (enable == true)
        {
          Instantiate(missle, startPosition, target.transform.rotation);
          missle.transform.position = Vector3.MoveTowards(startPosition, target.transform.position, speed * Time.deltaTime);
          Debug.Log("This is " + missle.transform.position);
        
        }

    }

}
