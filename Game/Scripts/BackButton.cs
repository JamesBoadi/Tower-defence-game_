using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {

	public void backButton(string No) 
	{
		SceneManager.LoadScene ("GameOpener"); // Loads start menu
	}
}