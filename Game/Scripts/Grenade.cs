using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
 
    public GameObject target;

    [SerializeField]
    public GameObject grenade;
    public GameObject explosion;
    private float speed = 0.5f;

    void Update()
    {
        moveGrenade();

    }
    public void moveGrenade()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - gameObject.transform.position;
            gameObject.transform.position += speed * direction * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D mortarTarget)
    {
        if (mortarTarget.gameObject.tag == "Enemy")
        {
            Decrease(mortarTarget.gameObject);
            StartCoroutine(DestroyObject(mortarTarget));
            
        }
    }

    IEnumerator DestroyObject(Collider2D mortarTarget)
    {
        
        yield return new WaitForSeconds(3f);
     
        GameObject.Destroy(gameObject);
        if(target != null)
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
    }

    void OnTriggerExit2D(Collider2D hit2)
    {
       StartCoroutine(DestroyObject(hit2));
       
    }

    private void Decrease(GameObject target)
    {
        HealthScript healthBar = target.GetComponent<HealthScript>();
        healthBar.DecreaseHealth(30);
    }






















}
/*  void OnTriggerEnter2D(Collider2D hit)
    {

        Collider2D[] collided = Physics2D.OverlapCircleAll(mortarbullet.transform.position, 1F);
        foreach (Collider2D col in collided)
        {
            if (col.gameObject.tag == "Enemy")
            {

                float distance = Vector3.Distance(mortarbullet.transform.position,col.transform.position);
            
                if (distance <= 0.75f)
                {
                 DecreaseSmallDamage(col.gameObject);
                 Debug.Log("True");
                }
                else if (distance <= 0.5f)
                {
                    DecreaseLargeDamage(col.gameObject);
                    Debug.Log("True2");
                }                
               
                // destroy_o = true;
            }

            
            

        }
        if (hit.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(gameObject);
            /*  if(gameObject == null)
              Instantiate(explosive, hit.transform.position, Quaternion.identity); */