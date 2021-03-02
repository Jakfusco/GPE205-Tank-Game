using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Powerup powerup;
    public AudioClip soundEffect;

    public void OnTriggerEnter(Collider other)
    {
        PowerupController powerupController = other.gameObject.GetComponent<PowerupController>();

        if (powerupController != null )
        {
            // Add the powerup to the powerup controller
            powerupController.Add(powerup);

            // Play sound effect if one exists
            if (soundEffect != null)
            {
                //Use PlayClipAtPoint when you are destroying the source of the audio
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }

            // Destroy this game object as it has been collected
            Destroy(this.gameObject);
        }
    }
}
