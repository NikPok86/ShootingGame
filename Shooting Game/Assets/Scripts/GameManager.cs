using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int[] wavesArray;
    public static int level;
    public EnemySpawner enemySpawner;

    void Start()
    {
        level = enemySpawner.level;
    }

    void Update()
    {
        
    }
    public void GameWaveUpdate()
    {
        wavesArray[level - 1] = enemySpawner.wave;
    }
}
