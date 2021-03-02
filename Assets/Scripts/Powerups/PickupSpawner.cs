using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupToSpawn;
    public GameObject spawnedPickup;
    public float secondUntilSpawn = 30f;
    private float secondsRemaining;

    private void Start()
    {
        SpawnPickup();
    }

    private void Update()
    {
        if (spawnedPickup == null)
        {
            secondsRemaining -= Time.deltaTime;
            if (secondsRemaining <= 0f)
            {
                SpawnPickup();
            }
        }
    }

    private void SpawnPickup()
    {
        //Spawn in the powerup
        spawnedPickup = Instantiate(pickupToSpawn, transform.position, Quaternion.identity);
        //Reset Timer
        secondsRemaining = secondUntilSpawn;
    }
}
