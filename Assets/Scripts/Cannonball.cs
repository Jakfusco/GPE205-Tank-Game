using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    //public GameObject attacker; // Tells the Shell who its parent is and who to give the point on a kill
    //public int attackDamage; // How much damage the shell will do on a hit
    public Attack attack; //Parses in Attack data


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(attack);
        if (collision.gameObject != attack.attacker) // Did I hit myself?
        {
            Debug.Log(collision.gameObject);
            Health otherTankHealth = collision.gameObject.GetComponent<Health>(); // Did whatever I hit have health?
            if (otherTankHealth != null) //If I did hit something that had health, deal damage.
            {
                otherTankHealth.TakeDamage(attack);
                //collision.gameObject.GetComponent<Health>().TakeDamage(attacker.GetComponent<Attack>());


            }
            // Destroy our cannonball when it runs into another object.
            Destroy(this.gameObject);
        }
    }

}
