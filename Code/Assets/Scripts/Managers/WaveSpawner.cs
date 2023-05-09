using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner instance;

    public Transform SpawnPoint;
    public Transform Enemies;
    [Header("Enemies")]
    public GameObject normalEnemyPrefab;
    public GameObject strongEnemyPrefab;
    public GameObject fastEnemyPrefab;
    public GameObject smallBossEnemyPrefab;
    public GameObject bigBossEnemyPrefab;


    public bool spawning = false;
    private bool hasSwitched = false;
    public int waveNumber = 0;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(hasSwitched && waveNumber % 5 != 0)
        {
            hasSwitched = false;
        }
        if(waveNumber % 5 == 0 && waveNumber > 0 && !spawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && !hasSwitched)
        {
            LevelSetup.instance.BuildRandomLevel();
            hasSwitched = true;
        }
    }

    public void StartWave()
    {
        spawning = true;
        Wave wave = Wave.waves[waveNumber];
        waveNumber++;
        StartCoroutine(SpawnWave(wave));
    }

    IEnumerator SpawnWave(Wave wave)
    {
        /*foreach(KeyValuePair<string, float> current in wave.wave)
        {
            SpawnEnemy(current.Key);
            yield return new WaitForSeconds(current.Value);
        }*/
        for(int i = 0; i < wave.enemies.Count; i++)
        {
            SpawnEnemy(wave.enemies[i]);
            yield return new WaitForSeconds(wave.delays[i]);
        }
        spawning = false;
        if(waveNumber == Wave.waves.Length - 1)
        {
            Game.instance.playing = false;
            GameMenu.instance.WinGame();
        }
    }

    void SpawnEnemy(string enemyName)
    {
        GameObject prefab;
        switch (enemyName)
        {
            case "normal":
                prefab = normalEnemyPrefab;
                break;
            case "fast":
                prefab = fastEnemyPrefab;
                break;
            case "strong":
                prefab = strongEnemyPrefab;
                break;
            case "smallBoss":
                prefab = smallBossEnemyPrefab;
                break;
            case "bigBoss":
                prefab = bigBossEnemyPrefab;
                break;
            default:
                prefab = normalEnemyPrefab;
                break;


        }
        GameObject enemy = Instantiate(prefab, SpawnPoint.position, SpawnPoint.rotation);
        enemy.transform.parent = Enemies;
    }
}
