using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapGenerationDropDown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown MapGenerationType;
    [SerializeField] private TMP_InputField CustomSeedInput;


    public void SetMapType()
    {
        Debug.Log("SetMapType() called");
        Debug.Log("Option is: " + MapGenerationType.captionText.text);
        if (MapGenerationType.captionText.text == "Random Seed")
        {
            Debug.Log("Random Seed Map Type");
            GameManager.Instance.mapType = GameManager.MapGenerationType.Random;
        }
        if (MapGenerationType.captionText.text == "Map Of The Day")
        {
            Debug.Log("Map Of The Day Map Type");
            GameManager.Instance.mapType = GameManager.MapGenerationType.MapOfTheDay;
        }
        if (MapGenerationType.captionText.text == "Custom Seed")
        {
            Debug.Log("Custom Seed Map Type");
            GameManager.Instance.mapType = GameManager.MapGenerationType.CustomSeed;

        }

    }
    public void SetCustomSeed()
    {
            GameManager.Instance.mapSeed = int.Parse(CustomSeedInput.text);
    }
}
