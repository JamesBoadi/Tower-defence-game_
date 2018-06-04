using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    
    private GameObject turret;
    private int cost;
    private int sellTurretCost;
    public bool deselectBoolean;

    static BuildManager instance;


    void Start()
    {
        instance = null; // Set buildmanager instance to null

    }

    public static BuildManager Instance // Buildmanager singleton 
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BuildManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = obj.AddComponent<BuildManager>();
                }
            }
            return instance;
        }
    }

    public void SelectTurretToBuild(GameObject turret_, int price) // return price and instance of turret
    {
        turret = turret_;
        cost = price;
    }

    public void Sellturretcost(int sell) // Return cost of selling turret
    {
        sellTurretCost = sell;
        GameManager.Instance.AddGold(sellTurretCost);
      
    }
    public void Sellturret(GameObject soldTurret) // Set the instance of the turret to null once sold
    {
        turret = soldTurret;
        GameObject.Destroy(turret);
        turret = null;
    }

    public void DeselectTurret(GameObject deselectturret) // Deselect turret
    {
        turret = deselectturret;
 
    }

    public int DeductCost // Return cost of turret
    {
        get
        {
            return cost;
        }

    }

    public GameObject Getturret // Return instance of turret
    {
        get
        {
            return turret;
        }
      
    }
   
}

/*

public GameObject object_; // laser turret
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
               
          // Create another instance of the turret     
           
      }

   public void SelectDoubleCannon()
   {
      
           Debug.Log("Laser Beamer Selected");
           BuildManager.Instance.SelectTurretToBuild(gameObject);
       

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

*/