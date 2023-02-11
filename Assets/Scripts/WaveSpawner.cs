using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform SpawnPoint;
    public Transform Enemies;

    //Temp for not. Waves will be manually started in final version
    public float timeBetweenWaves = 5f;
    public float timeToWave = 2f;

    public int waveNumber = 0;

    private void Update()
    {
        if(timeToWave <= 0f)
        {
            StartCoroutine(SpawnWave());
            timeToWave = timeBetweenWaves;
        }

        timeToWave -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        waveNumber++;
        for(int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
        enemy.transform.parent = Enemies;
    }
}
