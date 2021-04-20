using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Powerup
{
    public float speedMod = 0f;
    public int healthMod = 0;
    public int maxHealthMod = 0;
    public int damageMod = 0;
    public float fireRateMod = 0f; //Adjusts Cooldown Timer for Shooting Negative Number means Faster

    public float duration = 1.0f;
    public bool isPermanent = false;

    public void OnActivate(TankData targetData, Health targetHealth)
    {
        targetData.moveSpeed += speedMod;
        targetData.fireRate -= fireRateMod;
        targetData.cannonballDamage += damageMod;
        targetHealth.maxHealth += maxHealthMod;
        targetHealth.CurrentHealth += healthMod;
        

    }

    public void OnDeactivate(TankData targetData, Health targetHealth)
    {
        targetData.moveSpeed -= speedMod;
        targetData.fireRate += fireRateMod;
        targetData.cannonballDamage -= damageMod;
        targetHealth.maxHealth -= maxHealthMod;
        targetHealth.CurrentHealth -= healthMod;
    }
}
