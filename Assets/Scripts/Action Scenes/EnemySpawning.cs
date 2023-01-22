using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    private int enemySpawnCounter = 0;
    // Start is called before the first frame update

    [SerializeField]
    private float spawningInterval = 5;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawningInterval));
    }
    private IEnumerator spawnEnemy(float interval)
    {
        if (enemySpawnCounter < Random.Range(15, 20))
        {
            enemySpawnCounter += 1;
            yield return new WaitForSeconds(interval);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            int enemySpawned = Random.Range(0, 2);
            GameObject newEnemy = Instantiate(enemies[enemySpawned], spawnPoints[randSpawnPoint].position, transform.rotation);
            StartCoroutine(spawnEnemy(interval));
        }
    }
}
