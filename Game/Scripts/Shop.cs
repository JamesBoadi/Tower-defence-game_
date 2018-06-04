using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    private int[] costofTurrets = new int[]{300,400,500,550};

 
    public void SelectSingleCannon(GameObject singleCannon )
    {  
       BuildManager.Instance.SelectTurretToBuild(singleCannon,costofTurrets[0]);
    }

    public void SelectMissileLauncher(GameObject missleLauncher)
    {
        BuildManager.Instance.SelectTurretToBuild(missleLauncher,costofTurrets[1]);
    }

    public void SelectDoubleCannon(GameObject doubleCannon)
    {
       BuildManager.Instance.SelectTurretToBuild(doubleCannon,costofTurrets[2]);
    }

    public void SelectMortar(GameObject Mortar)
    {
        BuildManager.Instance.SelectTurretToBuild(Mortar, costofTurrets[3]);
    }
}
