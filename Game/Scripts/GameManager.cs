using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour  {

    public int gold;
    public int health;
    public Text goldlabel;
    public Text health_;
    public Text WaveDisplay;
    public bool gameover;
    public bool loadwave_;
    public bool load;
    public int currentwave;

    static GameManager instance;
 
    void Start()
    {
        instance = null; // Set the gamemanager instance to null
    }

    public static GameManager Instance  // Gamemanager singleton instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        gold = 2000;
        health = 100;
        currentwave = 0;
        gameover = false;
        goldlabel.GetComponent<Text>().text = gold.ToString();
        WaveDisplay.GetComponent<Text>().text = "Wave " + currentwave.ToString();
        health_.GetComponent<Text>().text = health.ToString();
        loadwave_ = true;
    }
    public void AddGold(int addGold)  // Add gold to players purse
    {
        gold += addGold;
        goldlabel.GetComponent<Text>().text = gold.ToString();
    }
    public void DeductGold(int deductGold) // Deduct gold from players purse
    {
        gold -= deductGold;
        goldlabel.GetComponent<Text>().text = gold.ToString();
    }
    public void DisplayWave(int wave) // Display the current wave
    {
        WaveDisplay.GetComponent<Text>().text = "Wave " + wave.ToString();
    }
    public void DecreaseHealth(int Health) // Decrease health if enemy reaches the endpoint
    {
        health -= Health;
        health_.GetComponent<Text>().text = health.ToString();

        if (health <= 0)
        {
            gameover = true;
        }
    }

    void ResetGame() // Reset the game
    {
        if (GameManager.Instance.gameover == true)
        {
            loadwave_ = true; 
        }
    }


}
