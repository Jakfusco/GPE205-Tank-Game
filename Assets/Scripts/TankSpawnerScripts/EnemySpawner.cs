using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public GameObject currentEnemy;
    public float respawnTimer = 30f;
    private float secondsRemaining;

    private void Start()
    {
        //SpawnEnemy();
    }

    private void Update()
    {
        if (currentEnemy == null)
        {
            secondsRemaining -= Time.deltaTime;
            if (secondsRemaining <= 0f)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        enemyToSpawn = GameManager.Instance.enemyAIPrefabs[Random.Range(0, GameManager.Instance.enemyAIPrefabs.Count - 1)];
        //Spawn in the enemy
        currentEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        //Reset Timer
        secondsRemaining = respawnTimer;
    }
}
