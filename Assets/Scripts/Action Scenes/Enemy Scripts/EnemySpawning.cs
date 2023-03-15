using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;

    public Transform bossSpawnPoints;
    public GameObject bossEnemy;

    private int enemySpawnCounter = 0;
    // Start is called before the first frame update

    [SerializeField]
    private float spawningInterval;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawningInterval));
    }
    private IEnumerator spawnEnemy(float interval)
    {
        spawningInterval = Random.Range(1f,3f);
        if (enemySpawnCounter < Random.Range(15, 20) && enemySpawnCounter <= 10)
        {
            enemySpawnCounter += 1;
            yield return new WaitForSeconds(interval);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            int enemySpawned = Random.Range(0, 3);
            GameObject newEnemy = Instantiate(enemies[enemySpawned], spawnPoints[randSpawnPoint].position, transform.rotation);
            StartCoroutine(spawnEnemy(interval));
        }

        if (enemySpawnCounter == 11)
        {
            enemySpawnCounter += 1;
            yield return new WaitForSeconds(10f);
            GameObject newEnemy = Instantiate(bossEnemy, bossSpawnPoints.position, transform.rotation);
            yield return 0;
        }

    }
}
