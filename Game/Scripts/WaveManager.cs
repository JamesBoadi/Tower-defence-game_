using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [System.Serializable]
    public class Wave // Stores the variables of the enemies to be spawned
    {
        public GameObject enemyPrefab;
        public GameObject combatVehicle;
        public float spawnInterval;
        public int maxEnemies;
    }

    [System.Serializable]
    public class BossWave // Stores the variables of the boss to be spawned
    {
        public GameObject boss;
        public float spawnInterval;
        public int maxEnemies;
    
    }
    
    List<GameObject> enemiesalive = new List<GameObject>();
    public Wave[] waves;
    public BossWave[] bosswave;
    private float lastSpawnTime;
    private int enemiesSpawned = 0;
    private int bossSpawned = 0;

    void Start()
    {
        GameManager.Instance.loadwave_ = false;  // Set loadwave to false to prevent waves from accidently spawning
    }

    void Update()
    {
        GameManager.Instance.load = true;
        int currentWave = GameManager.Instance.currentwave; 
        if (currentWave < waves.Length && GameManager.Instance.loadwave_ == true) 
        {
            float timeInterval = Time.time - lastSpawnTime; // Time between last enemy spawned
            float spawnInterval = waves[currentWave].spawnInterval; // Spawn interval between enemies spawned

            if ((enemiesSpawned == 0 && timeInterval > spawnInterval) || // While enemies spawned is set at zero and the time to spawn next enemy has passed
                timeInterval > spawnInterval && enemiesSpawned < waves[currentWave].maxEnemies)
            {
                GameManager.Instance.load = false;  // Spawn enemies
                lastSpawnTime = Time.time;
                Instantiate(waves[currentWave].enemyPrefab);
                Instantiate(waves[currentWave].combatVehicle);
                enemiesSpawned++;
            }

        

        }
            if (enemiesSpawned.Equals(waves[currentWave].maxEnemies)) // If all the enemies have spawned, set the game to load the next wave
            {
                if (enemiesalive.Count == 0 ) 
                {
                    GameManager.Instance.currentwave++;
                    GameManager.Instance.DisplayWave(GameManager.Instance.currentwave++);
                    GameManager.Instance.loadwave_ = false;
                    GameManager.Instance.load = true;
                    enemiesSpawned = 0;
                    lastSpawnTime = Time.time;
                }
            }
  
        }

    void OnTriggerEnter2D(Collider2D enemiesEntered) // Store enemies spawned in a list
    {
        if(enemiesEntered.gameObject.tag == "Enemy")
        {
            enemiesalive.Add(enemiesEntered.gameObject);
        }
       
    }

    public void Exit(GameObject enemiesExited)  // Remove enemies that have been destroyed or have reached the end point
    {
        enemiesalive.Remove(enemiesExited.gameObject);
       
    }



}



