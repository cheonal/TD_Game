using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;

    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex =0;
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
