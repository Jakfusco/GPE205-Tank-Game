using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public int attackDamage; // How much damage an attack will do
    public GameObject attacker; // Who initiated the attack

    public Attack(GameObject Attacker, int Damage) //Method is run whenever an attack is made
    {
        attackDamage = Damage;
        attacker = Attacker;
    }
}
