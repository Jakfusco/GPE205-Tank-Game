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
    }

    public void RespawnPlayer()
    {
        spawnPointToUse = GameManager.Instance.playerSpawnPoints[UnityEngine.Random.Range(0, GameManager.Instance.playerSpawnPoints.Length)];
        if (GameManager.Instance.Players[0] == null)
        {
            GameObject newPlayer = Instantiate(GameManager.Instance.playerPrefab, spawnPointToUse.transform);
            GameManager.Instance.Players[0] = newPlayer;
            newPlayer.GetComponent<InputController>().MakeInputArrows();

        }
        if (GameManager.Instance.Players[1] == null)
        {
            GameObject newPlayer = Instantiate(GameManager.Instance.playerPrefab, spawnPointToUse.transform);
            GameManager.Instance.Players[1] = newPlayer;
            newPlayer.GetComponent<InputController>().MakeInputWASD();

        }



    }
}

