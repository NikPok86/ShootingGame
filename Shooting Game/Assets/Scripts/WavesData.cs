using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
public class WavesData
{
    public int wave;

    public WavesData (EnemySpawner enemySpawner)
    {
        wave = enemySpawner.wave;
    }
}
