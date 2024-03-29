﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(TankData))]
public class Health : MonoBehaviour
{
    //Variables
    public TankData data;

    private int currentHealth = 5; // Current Health of The Tank
    public int CurrentHealth
    {
        get { return currentHealth; }

        set
        {
            currentHealth = value;
            if (currentHealth <= 0)
            {
                Die();
            }
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
    public int maxHealth = 5; // Maximum Health of The Tank

    public void TakeDamage(Attack attackData)
    {
        currentHealth -= attackData.attackDamage;

        
        // check to see if we died
        if (currentHealth <= 0)
        {
            if (attackData.attacker.gameObject.tag == "Player")
            {
                GameManager.Instance.player1Score += data.killScore;
            }
            else if (attackData.attacker.gameObject.tag == "Player2")
            {
                GameManager.Instance.player2Score += data.killScore;
            }
            Die();
        }
    }

    public void Die()
    {
        if (this.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(3); //If the player dies, they go to the game over scene
        }
        else
        {
            Debug.Log("I died. Goddammit I should have bought life insurance");
            Destroy(this.gameObject); //If the tank that dies is not a player, the game object is just destroyed.

        }

    }

    private void Start()
    {
        data = GetComponent<TankData>(); 
    }
}
