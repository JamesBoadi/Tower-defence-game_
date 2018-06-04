using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col : MonoBehaviour {

	public GameObject object_;
    public bool Enable;
    private bool check;
    public bool get;
    private GameObject temp;

    void Start()
    {

        check = false;
    }
    void Update()
    {

        OnMouseDown();
        SelectTurret();
       
        
    }

   void SelectTurret()
    {
        Vector3 mouseposition = Input.mousePosition;
        Vector3 mouseposition_ = Camera.main.ScreenToWorldPoint(mouseposition); // Translate the position of the mouse into real coordinates
        mouseposition_.z = transform.position.z;
        if (check == true)
        temp = (GameObject)Instantiate(object_, transform.position, transform.rotation);
        
        temp.transform.position = Vector3.MoveTowards(temp.transform.position, mouseposition_, Time.deltaTime * 5); 
     
        


       
       
          // Create another instance of the turret     
             
 
      }

   public void SelectDoubleCannon()
   {
      
           Debug.Log("Laser Beamer Selected");
           
       

   }
   void OnMouseDown()
   {
       if (Input.GetMouseButtonDown(0) && temp == null)
       {
           check = true;
           SelectDoubleCannon();
           Debug.Log("So null");

       }
       else
       {
           check = false;
      }

       if (Input.GetMouseButtonDown(1))
       {

           temp = null;
           check = false;
       }
   }

  
   

      // add script to disable gameobject so that it can always be retrieved given enough cash
        //Instantiate(object_, mouseposition_, Quaternion.identity);


	// http://answers.unity3d.com/questions/991395/gameobject-follow-mouse-on-center.html
}

