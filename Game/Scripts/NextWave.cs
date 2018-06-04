using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWave : MonoBehaviour {

   public void ActivateWave()
    {
        if (GameManager.Instance.load == true) // Load the next wave
        { 
            GameManager.Instance.loadwave_ = true; 
        
        }
 
        if (GameManager.Instance.load == false) // Disable the wave from loading
        {     
         GameManager.Instance.loadwave_ = false;
              
        }
    }




}
