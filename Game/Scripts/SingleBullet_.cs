using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBullet_ : MonoBehaviour {

    // Use this for initialization

  
    public GameObject target;

    [SerializeField]
    public GameObject sinlgeBullet;
    public GameObject explosion;
    public GameObject emitter;
    private float speed = 3.5f;

    void Update()
    {
        movesingleBullet();


    }
    public void movesingleBullet() 
    {
        if (target != null) // If a target exists, fire bullet towards the target
        {
            Vector3 direction = target.transform.position - gameObject.transform.position;
            gameObject.transform.position += speed * direction * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D singleBullet) // If the target has hit the enemy, destroy it
    { 
    
        if (singleBullet.gameObject.tag == "Enemy")
        {
            Decrease(singleBullet.gameObject);
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D singleBullet) // Destroy bullet if it richochets off the enemy
    {
        GameObject.Destroy(gameObject);
    }


    private void Decrease(GameObject target) // Decrease the health of the enemy
    {
        HealthScript healthBar = target.GetComponent<HealthScript>();
        healthBar.DecreaseHealth(15);
    }


}
