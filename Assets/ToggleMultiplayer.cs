using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMultiplayer : MonoBehaviour
{
    public void OnMultiplayerToggle()
    {
        if (GameManager.Instance.isMultiplayer == false)
        {
            GameManager.Instance.isMultiplayer = true;
        }
        else
        {
            GameManager.Instance.isMultiplayer = false;
        }
    }
}
