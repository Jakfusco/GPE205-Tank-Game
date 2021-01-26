using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTimer1 : MonoBehaviour
{
    public float TimeToWait = 1.0f;
    private float NextEvent;
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    /// <summary>
    /// Resets the Timer
    /// </summary>
    private void ResetTimer()
    {
        NextEvent = Time.time + TimeToWait;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= NextEvent)
        {
            Debug.Log("The Game was rigged from the start.");
            ResetTimer();
        }

    }


}
