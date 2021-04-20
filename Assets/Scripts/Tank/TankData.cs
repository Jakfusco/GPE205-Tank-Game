using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    //Handling Move Speed
    public float moveSpeed = 3.0f;
    //Handling Rotation
    public float turnSpeed = 30.0f;

    public float fireRate = 1.0f;

    public int killScore = 1;

    //Berseker Tank Data
    public float explosionRadius = 6.0f;



    //Handling Cannonballs
    public int cannonballDamage = 1; // How much damage the tank will do with its shots
    public float reloadTime = 1.0f; // How long the tank takes to reload.

    //Handling Shot Speed
    public int shotSpeed = 1000; // Handles the shot speed for individual bullet types

    //Make a note to look up active reloading in Unity
}
