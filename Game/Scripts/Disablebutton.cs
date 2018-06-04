using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disablebutton : MonoBehaviour {

    public Canvas displaybutton;
    private Canvas display;

	void Start () 
    {
        displaybutton.gameObject.SetActive(false);
	}
    void Update()
    {
        Display();
    }
    void Display()
    {
        display = displaybutton;

        if (Input.GetMouseButtonDown(0))
        {
            display.gameObject.SetActive(true);
            Debug.Log("True");
        }

        

    
    }
}
