using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {


    void Update()
    {

        SelectTurret();
    }

    public void SelectTurret()
    {
        Vector3 mouseposition = Input.mousePosition;
        Vector3 mouseposition_ = Camera.main.ScreenToWorldPoint(mouseposition); // Translate the position of the mouse into real coordinates
        mouseposition_.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, mouseposition_, Time.deltaTime * 5);
    }




    // Activate and Deactivate feature
}
