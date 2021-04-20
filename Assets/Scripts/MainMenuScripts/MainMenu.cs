using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Slider BGMSlider;
    public Slider SFXSlider;
    public Slider rowSlider;
    public Slider columnSlider;
    public void OnQuitClicked()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OnPlayClicked()
    { 

        SceneManager.LoadScene(2);
       
    }

    public void OnBGMSliderValueChange()
    {
        GameManager.Instance.musicVolume = BGMSlider.value;
    }
    public void OnSFXSliderValueChange()
    {
        GameManager.Instance.sfxVolume = SFXSlider.value;
    }

    public void OnRowSliderValueChange()
    {
        GameManager.Instance.rows = (int)rowSlider.value;
    }
    public void OnColumnSliderValueChange()
    {
        GameManager.Instance.columns = (int)columnSlider.value;
    }
}
