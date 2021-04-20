using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioClip menuMusic; //Music for Menu
    public AudioClip mainMusic; //Music for Game
    public AudioSource audioSource;

    private void Update()
    {
        audioSource.volume = GameManager.Instance.musicVolume;
        if (SceneManager.GetActiveScene().name == "TitleScreen" || SceneManager.GetActiveScene().name == "GameOverScene")
        {
            audioSource.clip = menuMusic;
            if (!(audioSource.isPlaying))
            {
                audioSource.Play();
            }
        }
        else if (SceneManager.GetActiveScene().name == "Main")
        {
            audioSource.clip = mainMusic;
            if (!(audioSource.isPlaying))
            {
                audioSource.Play();
            }
        }
    }
}
