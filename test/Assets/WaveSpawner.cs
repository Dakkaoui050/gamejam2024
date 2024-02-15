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

    public Transform pointA;
    public Transform pointB;

    [SerializeField] private float moveSpeed = 5f;

    private Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("buildZone").GetComponent<Transform>();
        // Start by moving towards pointB
        pointA = spawnPoints.Length > 0 ? spawnPoints[0] : transform;
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

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Check if the AI has reached the current target
        if (Vector2.Distance(transform.position, target.position) < 0.01f)
        {
            
            if (target == pointA)
                SetTarget(pointB);
            else
                SetTarget(pointA);
        }
    }

    private void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
