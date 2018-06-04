using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullettwo : MonoBehaviour {

    public GameObject target2;

    [SerializeField]
    public GameObject bull2;
    private float speed = 1f;
   

    void Update()
    {

        moveBullet();
      
    }
    public void moveBullet() 
    {
        if (target2 != null)  // If a target still exists, fire bullet in that direction
        {
            Vector3 direction = target2.transform.position - gameObject.transform.position;
            gameObject.transform.position += speed * direction * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D bullet2Target) // Destroy bullet if it hits target
    {
        if (bullet2Target.gameObject.tag == "Enemy")
        {
            Decrease(bullet2Target.gameObject);
            GameObject.Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D bullet2Target) // Destroy bullet if it ricochets off target
    {
        GameObject.Destroy(gameObject);
    }

    private void Decrease(GameObject target) // Decrease enemy health
    {
        HealthScript healthBar = target.GetComponent<HealthScript>();
        healthBar.DecreaseHealth(7);
    }
}
