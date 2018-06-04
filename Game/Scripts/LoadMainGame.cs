using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	public void Click(string scene)
	{
        GameManager.Instance.gameover = false;
		SceneManager.LoadScene (scene);
   
	

	}
}



