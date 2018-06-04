using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using System.Linq;

public class PlaceTurret : MonoBehaviour {

    private GameObject turret;
    public Vector3 mouseposition_;
    private Camera mainCamera;



    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mouseposition = Input.mousePosition; // Get the mouse position
        mouseposition_ = Camera.main.ScreenToWorldPoint(mouseposition);
        mouseposition_.z = transform.position.z;
        OnMouseDown();
    }

    public void BuildTurret(GameObject Turret)
    {
        turret = (GameObject)Instantiate(Turret, mouseposition_, Quaternion.identity); // Get the current turret
       
    }

   private void OnMouseDown() 
    {
        if (Input.GetMouseButton(0)) // Clicking to place the turret on the map
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Initialize the ray 
            RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(ray.origin.x + 1f,ray.origin.y + 1f), ray.direction); 
            // Raycast points to objects stored in array
 
            if (hits.Length > 0 && hits[0].collider != null )
            {
                GameObject turret_ = BuildManager.Instance.Getturret;  // Get the turret;
                                                                      // Make the turret position equal to position that was clicked
                turret = turret_;
                turret_.transform.position = hits[0].point;  // fix   get the child object
                if ((hits.Where(x => x.collider.gameObject.tag == "Turret" 
                    || x.collider.gameObject.tag == "Path").Count()) > 0) // If turret is placed on another turret or path, the user cannot place it
                {
                   
                    return;
                }
             
                else 
                {
                    int gold = GameManager.Instance.gold;

                    if (gold <= 0 || gold - BuildManager.Instance.DeductCost <= 0) // Do nothing if player doesn't have enough gold
                    {
                        return;
                    }
                    else {

                        BuildTurret(BuildManager.Instance.Getturret); // Build the turret
                        GameManager.Instance.DeductGold(BuildManager.Instance.DeductCost);
          
                    }
                 

                }

            }
        }
    }

      
   


}






  
 


    
     
     


