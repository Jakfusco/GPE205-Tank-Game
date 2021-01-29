using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public GameObject attacker; // Tells the Shell who its parent is and who to give the point on a kill
    public int attackDamage; // How much damage the shell will do on a hit

    private void OnCollisionEnter(Collision collision)
    {
        Attack attackData = new Attack(attacker, attackDamage);
        collision.gameObject.SendMessage("TakeDamage", attackData);

         //Destroy our cannonball when it runs into another object.
         Destroy(this.gameObject);
    }

}
