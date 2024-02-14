using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    public int numberOfEnemiesInWave = 5;
    public float timeBetweenSpawns = 1f;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            currentWave++;

            foreach (Transform spawnPoint in spawnPoints)
            {
                for (int i = 0; i < numberOfEnemiesInWave; i++)
                {
                    SpawnRandomEnemy(spawnPoint);
                    yield return new WaitForSeconds(timeBetweenSpawns);
                }
            }
        }
    }

    void SpawnRandomEnemy(Transform spawnPoint)
    {
        GameObject randomEnemyPrefab = GetRandomEnemyPrefab();
        Instantiate(randomEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    GameObject GetRandomEnemyPrefab()
    {
        return enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
    }

}
