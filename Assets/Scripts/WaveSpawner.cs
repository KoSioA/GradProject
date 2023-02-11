using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    public GameObject enemyPrefab;
    public Transform SpawnPoint;
    public Transform Enemies;

    public bool spawning = false;

    public int waveNumber = 0;
    private void Awake()
    {
        instance = this;
    }

    public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        spawning = true;
        waveNumber++;
        for(int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        spawning = false;
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        enemy.transform.parent = Enemies;
    }
}
