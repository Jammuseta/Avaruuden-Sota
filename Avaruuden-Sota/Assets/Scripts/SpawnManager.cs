using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject pelaaja;
    public float spawnRange = 20f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Satunnainen x-koordinaatti välillä -100 ja 100
        float spawnPosX = Random.Range(-100f, 100f);

        // Satunnainen z-koordinaatti annetulla spawn-alueella
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        // Varmistetaan, että y-koordinaatti on vähintään 13
        float spawnPosY = Mathf.Max(13f, Random.Range(13f, spawnRange));

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return randomPos;
    }






    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
}
