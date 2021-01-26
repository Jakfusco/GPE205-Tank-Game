using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTimer2 : MonoBehaviour
{
    public float TimeToWait = 1.0f;
    private float PreviousEvent;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (PreviousEvent < (Time.time - TimeToWait))
        {
            Debug.Log("And so the courier who cheated death cheated it again, and the Mojave was forever changed.");
        }
    }

    void ResetTimer()
    {
        PreviousEvent = Time.time;
    }
}
