using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankData))]
[RequireComponent(typeof(AudioSource))]
public class TankShooter : MonoBehaviour
{
    public GameObject firePoint; // Use this point in space for instantiating cannon balls
    public GameObject cannonBallPrefab;
    private TankData data;
    private AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponent<TankData>();
        sfx = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
            sfx.volume = GameManager.Instance.sfxVolume;

    }

    public void shoot()
    {
        Noisemaker noisemaker = gameObject.GetComponent<Noisemaker>();
        // Check cooldown timer to see if we can shoot.

        // Instantiate the cannon ball.
            GameObject firedCannonBall = Instantiate(cannonBallPrefab, firePoint.transform.position, Quaternion.identity) as GameObject;
            Rigidbody cannonRB = firedCannonBall.GetComponent<Rigidbody>();
            // Propel the cannon ball forward with Rigidbody.AddForce()
            cannonRB.AddForce(firePoint.transform.forward * data.shotSpeed);
            // The cannon ball needs some data: Who fired it, and how much damage will it do?
            Cannonball cannonBall = firedCannonBall.GetComponent<Cannonball>();
            cannonBall.attack = new Attack(this.gameObject, data.cannonballDamage);
            Debug.Log(cannonBall.attack);
            gameObject.SendMessage("AddNoise", value: 5, SendMessageOptions.DontRequireReceiver);
            sfx.Play();
        

    }

}





