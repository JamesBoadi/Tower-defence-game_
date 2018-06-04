using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    private float maxhealth;
    public float ratio;

    [SerializeField]
    public float minhealth = 100;

    [SerializeField]
    public Image healhBar;
    public GameObject explosion;


    void Start()
    {
        maxhealth = minhealth;
    
    }
   public void DecreaseHealth(float damage) // Decrease health of enemy
   {
        minhealth -= damage;    // Decrease the minimum health when damage is done to enemy
        ratio = (minhealth / maxhealth);
        healhBar.fillAmount = Mathf.Clamp(ratio, 0, 1); // Clamp the health of the healthbar over a percentile of 0 and 1

        if (minhealth <= 0)
        {
            RemoveGameObject(); 
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            GameManager.Instance.AddGold(15);
            GameObject.Destroy(gameObject);
        }

    }

    public void RemoveGameObject() // Remove the gameobject from the list
   {
       var startWave = GameObject.Find("Manager").GetComponent<WaveManager>();
       startWave.Exit(gameObject);

   }





}