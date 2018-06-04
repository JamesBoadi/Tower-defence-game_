using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletone : MonoBehaviour {

    public GameObject target;

    [SerializeField]
    public GameObject bull1;
    private float speed = 3f;

    void Update()
    {
        moveBullet();
    }
    public void moveBullet()  
    {
        if (target != null)  // If the target still exists, fire bullet in that direction
        {
            Vector3 direction = target.transform.position - gameObject.transform.position;
            gameObject.transform.position += speed * direction * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D bullet1Target) // If bullet1 has hit the target, destroy the bullet
    {
        if (bullet1Target.gameObject.tag == "Enemy")
        {
           GameObject.Destroy(gameObject);
            Decrease(bullet1Target.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D bullet1Target) // Destroy bullet if it has ricocheted off the target
    {
        GameObject.Destroy(gameObject);
    }
    
    private void Decrease(GameObject target) // Decrease enemy health
    {
        HealthScript healthBar = target.GetComponent<HealthScript>();
        healthBar.DecreaseHealth(15);
    }





}
