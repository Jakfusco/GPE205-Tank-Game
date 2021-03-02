using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    //Variables
    private int currentHealth = 1; // Current Health of The Tank
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
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("I died. Goddammit I should have bought life insurance");
        Destroy(this.gameObject);
    }
}
