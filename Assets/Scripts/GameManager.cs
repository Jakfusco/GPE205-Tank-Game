using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject playerPrefab;

    public GameObject[] Players = new GameObject[2];

    public List<EnemySpawnPoints> enemySpawnPoints = new List<EnemySpawnPoints>();

    public List<GameObject> enemyAIPrefabs = new List <GameObject>();
    public GameObject[] playerSpawnPoints;
    public GameObject projectilePrefab;

    public bool isMultiplayer;

    public int playerScore = 0;

    public float musicVolume;

    public float sfxVolume;

    public enum MapGenerationType { Random, MapOfTheDay, CustomSeed };
    public MapGenerationType mapType = MapGenerationType.Random;
    protected override void Awake()
    {
        base.Awake();
    }

    public void Start()
    {
        enemyAIPrefabs.AddRange(GameObject.FindGameObjectsWithTag("enemyTank"));
        SceneManager.LoadScene(1);
    }

    public void SavePreferences()
    {
        //Save Music Volume
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.SetInt("mapType", (int) mapType); //Test this out
        PlayerPrefs.Save();
    }

    public void LoadPreferences()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {
            musicVolume = 1.0f;
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            sfxVolume = 1.0f;
        }
        if (PlayerPrefs.HasKey("mapType"))
        {
            mapType = (MapGenerationType)PlayerPrefs.GetInt("mapType"); 
        }
        else
        {
            mapType = MapGenerationType.Random;
        }

    }

    public void SaveChangesOnClicked()
    {
        GameManager.Instance.LoadPreferences();
    }

}
