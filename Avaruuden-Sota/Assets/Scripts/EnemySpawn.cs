using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemyPrefabs;
    public float spawnRangeX, spawnRangeY;
    public int enemyCount;
    public int waveNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<vihu1>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    void spawnenemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeY, 0);
    }
}
