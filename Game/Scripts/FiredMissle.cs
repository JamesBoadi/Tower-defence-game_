using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredMissle : MonoBehaviour {

	// Use this for initialization
    public GameObject target;

    [SerializeField]
    public GameObject missileprefab;
    public GameObject explosion;
    public GameObject emitter;
    private float speed = 1.5f;

    void Update()
    {
        shootMissle();
    }
    public void shootMissle()
    {
        GameObject missle = gameObject;

        if (target != null) // if target still exists, fire missle
        {
            Vector3 direction = target.transform.position - missle.transform.position;
            missle.transform.position += speed * direction * Time.deltaTime;
        }   
    }
    void OnTriggerEnter2D(Collider2D missleTarget) // destroy missle if it hits target
    {
        if (missleTarget.gameObject.tag == "Enemy")
        {
            DecreaseHealth(missleTarget.gameObject);
            GameObject.Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D missleTarget) // destroy missle if it ricochets off target
    {
       GameObject.Destroy(gameObject);
    }

   private void DecreaseHealth(GameObject target) // decrease enemy health
   {
     HealthScript healthBar = target.GetComponent<HealthScript>();
     healthBar.DecreaseHealth(50);
   }
   




}
