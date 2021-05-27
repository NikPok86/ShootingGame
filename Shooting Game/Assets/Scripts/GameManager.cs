using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int[] wavesArray;
    public static int level;
    public EnemySpawner enemySpawner;

    void Start()
    {
        int[] wavesArray = new int[20];
        //level = enemySpawner.level; 
        level = 1;
        //PlayerPrefs.SetInt("HighWave", enemySpawner.wave);
        PlayerPrefs.SetInt("HighWave", 0);
        //Debug.Log(enemySpawner.wave);
    }

    void Update()
    {
        
    }
    public void GameWaveUpdate()
    {
        if (enemySpawner.wave > PlayerPrefs.GetInt("HighWave", 0))
        {
            PlayerPrefs.SetInt("HighWave", enemySpawner.wave);
            Debug.Log(PlayerPrefs.GetInt("HighWave", enemySpawner.wave));
        }

        wavesArray[level - 1] = PlayerPrefs.GetInt("HighWave", enemySpawner.wave);
    }
}
