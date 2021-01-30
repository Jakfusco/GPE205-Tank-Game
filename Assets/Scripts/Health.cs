using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health : MonoBehaviour
{
    //Variables
    public int currentHealth = 5; // Current Health of The Tank
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
