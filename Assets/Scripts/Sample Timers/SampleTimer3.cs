using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleTimer3 : MonoBehaviour
{
    public float TimeToWait = 1.0f;
    private float TimeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        TimeRemaining -= Time.deltaTime;
        if (TimeRemaining <= 0)
        {
            Debug.Log("What in The Goddamm?");
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        TimeRemaining = TimeToWait;
    }
}
