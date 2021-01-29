using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
public class TankShooter : MonoBehaviour
{
    public GameObject firePoint; // Use this point in space for instantiating cannon balls
    public GameObject cannonBallPrefab;
    private TankData data;
    private bool canFire = true;
    private float reloadTimeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void shoot()
    {
        // Check cooldown timer to see if we can shoot.

        // Instantiate the cannon ball.
        if (canFire == 'False')
        {
            reloadTimer();
        }
        else
        {
            GameObject firedCannonBall = Instantiate(cannonBallPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;
            Rigidbody cannonRB = firedCannonBall.GetComponent<Rigidbody>();
            // Propel the cannon ball forward with Rigidbody.AddForce()
            cannonRB.AddForce(firePoint.transform.forward * data.shotSpeed);
            // The cannon ball needs some data: Who fired it, and how much damage will it do?
            Cannonball cannonBall = firedCannonBall.GetComponent<Cannonball>();
            cannonBall.attacker = this.gameObject;
            cannonBall.attackDamage = data.cannonballDamage;
        }

    }

    private void reloadTimer()
    {
        if (canFire == 'False')
        {

        }
    }
}





