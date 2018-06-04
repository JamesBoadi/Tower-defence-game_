using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeselectNode : MonoBehaviour {


    void Update()
    {
        DetectClick();
    }

    void DetectClick()
    {
        if (Input.GetMouseButtonDown(0) && BuildManager.Instance.Getturret != null ) // Remove the instance of the turret if another area has been clicked
        {
            Debug.Log("true");
            BuildManager.Instance.DeselectTurret(BuildManager.Instance.Getturret);
          

        }

     
    
    }

  




}
