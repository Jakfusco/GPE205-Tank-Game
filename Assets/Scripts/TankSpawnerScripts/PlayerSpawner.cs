using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject spawnPointToUse;
    private void Start()
    {
        playerOne = GameManager.Instance.Players[0];
        playerTwo = GameManager.Instance.Players[1];
    }
    private void Update()
    {
        if (playerOne == null)
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
            spawnPointToUse = GameManager.Instance.playerSpawnPoints[UnityEngine.Random.Range(0, GameManager.Instance.playerSpawnPoints.Length)];
            Instantiate(GameManager.Instance.playerPrefab, spawnPointToUse.transform);
    }
}
