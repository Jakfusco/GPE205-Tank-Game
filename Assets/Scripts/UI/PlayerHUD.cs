using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Health))] //Required for the script to run
public class PlayerHUD : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = health.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = ("Health: " + health.CurrentHealth.ToString());
        scoreText.text = ("Score:  " + GameManager.Instance.playerScore.ToString());
    }
}
