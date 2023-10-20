using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomZombieSpawn : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnPoints;

    public bool stopSpawn;
    public float spawnAni, spawnAraligi;

    // Start is called before the first frame update
    void Start()
    {
        stopSpawn = false;
        //SpawnZombie();
        InvokeRepeating("Spawn", spawnAni, spawnAraligi);
    }

    /*private void OnEnable()
    {
        Zombie.OnEnemyKilled += SpawnZombie;
    }*/

    /*void SpawnZombie()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)],spawnPoints[i]);
        }
    }*/
    void Spawn()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnPoints[i]);
        }
        if (stopSpawn)
        {
            CancelInvoke("Spawn");

        }
    }

    /*IEnumerator EnemySpawn()
    {
        while (enemyCount < 10)
        {
            Instantiate()
        }
    }*/
}
