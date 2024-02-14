using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefab;
    public Transform[] blockSpawnPoint;
    public float timerValue;
    public float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SpawnBlock();
            timer = timerValue;
        }
    }

    public void SpawnBlock()
    {
        Transform spawnToSpawn = blockSpawnPoint[Random.Range(0, blockSpawnPoint.Length - 1)];
        GameObject blockToSpawn = blockPrefab[Random.Range(0,blockPrefab.Length-1)];
        Instantiate(blockToSpawn,spawnToSpawn);
    }
}
