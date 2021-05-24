using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnEffect;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float Timer;
    public float spawnRate;
    public float nextSpawn;

    public int wave = 1;
    public int enemyCount;
    int waveEndCount = 0;

    public Score st;
    public WaveText wt;
    public WaveText bwt;
    public GameObject bigWavesText;
    public GameObject levelCompletedText;

    void Start()
    {
        nextSpawn = spawnRate; 
        Invoke("BigWavesTextOn", 1.5f);
    }

    void Update()
    {
        Timer += Time.deltaTime;

        switch (wave)
        {
            case 1: 
                enemyCount = 3;
                spawnRate = 3f;
                FirstWave();
                if (st.score == enemyCount * 100)
                {
                    waveEndCount = 0;
                    wave++;
                    Timer = nextSpawn - 5f;
                    enemyCount += 4;
                    wt.UpdateWaveText(wave);
                    bwt.UpdateWaveText(wave);
                    Invoke("BigWavesTextOn", 1.5f);
                }
                break;

            case 2:
                spawnRate = 3f;
                SecondWave();
                if (st.score == enemyCount * 100)
                {
                    waveEndCount = 0;
                    wave++;
                    Timer = nextSpawn - 5f;
                    enemyCount += 4;
                    wt.UpdateWaveText(wave);
                    bwt.UpdateWaveText(wave);
                    Invoke("BigWavesTextOn", 1.5f);
                }
                break;

            case 3:
                spawnRate = 2f;
                ThirdWave();
                if (st.score == enemyCount * 100)
                {
                    waveEndCount = 0;
                    wave++;
                    Timer = nextSpawn - 5f;
                    enemyCount += 5;
                    wt.UpdateWaveText(wave);
                    bwt.UpdateWaveText(wave);
                    Invoke("BigWavesTextOn", 1.5f);
                }
                break;

            case 4:               
                spawnRate = 1f;
                FourthWave();
                if (st.score == enemyCount * 100)
                {
                    waveEndCount = 0;
                    wave++;
                    Timer = nextSpawn - 5f;
                    enemyCount += 5;
                    wt.UpdateWaveText(wave);
                    bwt.UpdateWaveText(wave);
                    Invoke("BigWavesTextOn", 1.5f);
                }
                break;

            case 5:           
                spawnRate = 0.5f;
                FifthWave();
                if (st.score == enemyCount * 100)
                {
                    waveEndCount = 0;
                    wave = 0;
                    Timer = nextSpawn - 5f;
                    Invoke("LevelCompletedOn", 1.5f);
                }
                break;
            
            default:
                break;
        }
    }

    public void SpawnEffect()
    {
        randX = Random.Range(-6f, 6.1f);
        randY = Random.Range(-4.4f, 0f);
        whereToSpawn = new Vector2 (randX, randY);
        Transform newSpawnEffect = Instantiate (spawnEffect, whereToSpawn, Quaternion.identity);
        Destroy (newSpawnEffect.gameObject, 0.4f);
        Invoke("Spawning", 0.4f);
    }

    public void Spawning()
    {
        Instantiate (enemy, whereToSpawn, Quaternion.identity);
    }

    public void FirstWave()
    {
        if (Timer > nextSpawn)
        {
            if (waveEndCount < 3)
            {
                nextSpawn = Timer + spawnRate;
                SpawnEffect();
                waveEndCount++;
            }
        }
    }

    public void SecondWave()
    {
        if (Timer > nextSpawn)
        {
            if (waveEndCount < 4)
            {
                nextSpawn = Timer + spawnRate;
                SpawnEffect();
                waveEndCount++;
            }
        }
    }

    public void ThirdWave()
    {
        if (Timer > nextSpawn)
        {
            if (waveEndCount < 4)
            {
                nextSpawn = Timer + spawnRate;
                SpawnEffect();
                waveEndCount++;
            }
        }
    }

    public void FourthWave()
    {
        if (Timer > nextSpawn)
        {
            if (waveEndCount < 5)
            {
                nextSpawn = Timer + spawnRate;
                SpawnEffect();
                waveEndCount++;
            }
        }
    }

    public void FifthWave()
    {
        if (Timer > nextSpawn)
        {
            if (waveEndCount < 5)
            {
                nextSpawn = Timer + spawnRate;
                SpawnEffect();
                waveEndCount++;
            }
        }
    }

    public void BigWavesTextOn()
    {
        bigWavesText.SetActive(true);
        Invoke("BigWavesTextOff", 1.5f);
    }

    public void BigWavesTextOff()
    {
        bigWavesText.SetActive(false);
    }

    public void LevelCompletedOn()
    {
        levelCompletedText.SetActive(true);
        Invoke("LevelCompletedOff", 1.5f);
    }

    public void LevelCompletedOff()
    {
        levelCompletedText.SetActive(false);
        SceneManager.LoadScene("AllLevels");
    }
}
