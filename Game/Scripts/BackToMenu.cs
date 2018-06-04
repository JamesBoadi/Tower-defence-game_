using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

    public void backtoMenu(string loadScene)
    {
        SceneManager.LoadScene(loadScene); // Loads next scene passed by parameter loadscene
    }

}
