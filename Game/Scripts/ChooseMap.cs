using UnityEngine;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour {

	public void chooseMap(string loadScene)
	{
		SceneManager.LoadScene(loadScene); // Loads next scene passed by parameter loadscene
        GameManager.Instance.gameover = false;
	}
}


