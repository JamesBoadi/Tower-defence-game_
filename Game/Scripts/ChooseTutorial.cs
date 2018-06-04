using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseTutorial : MonoBehaviour {


    public void chooseTutorial(string loadScene)
    {
        SceneManager.LoadScene(loadScene); // Loads next scene passed by parameter loadscene
    }
}
