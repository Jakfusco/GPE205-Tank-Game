using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noisemaker : MonoBehaviour
{
    public float noiseRadius = 0.0f;
    public float closeEnough = 1.0f;
    public float NoiseRadius
    {
        get
        {
            return noiseRadius;
        }
        set
        {
            noiseRadius = Mathf.Max(noiseRadius, value);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (noiseRadius > 0)
        {
            Debug.Log(noiseRadius);
            noiseRadius = noiseRadius * 0.7f;
            if (noiseRadius <= closeEnough)
            {
                noiseRadius = 0;
            }
        }

    }

    public void AddNoise(float noiseLevel)
    {
        noiseRadius = noiseLevel;
    }
}
