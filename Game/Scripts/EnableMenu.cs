using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableMenu : MonoBehaviour {

	// Use this for initialization
    private bool pausegame;

    void Start()
    {
        GameManager.Instance.gameover = false;
    }
    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (pausegame == true)
        { 
        Time.timeScale = 0; // Stop the game from running
        BuildManager.Instance.gameObject.SetActive(false);
        }
        else { BuildManager.Instance.gameObject.SetActive(true); // Enable game
        Time.timeScale = 1; 
        }
    }

    public void Menu(GameObject menu) // Enable the pause menu
    {
        menu.gameObject.SetActive(true);
        pausegame = true;
    }

    public void DisableMenu(GameObject disablemenu) // Disable the pause menu
    {
        disablemenu.gameObject.SetActive(false);
        pausegame = false;
        BuildManager.Instance.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void LoadStartMenu(string menu) // Load the start menu and restore the current state of the game
    {
        Time.timeScale = 1;
        pausegame = false;
        BuildManager.Instance.gameObject.SetActive(true);
        GameManager.Instance.gameover = true;
        SceneManager.LoadScene(menu); 
    }


}
