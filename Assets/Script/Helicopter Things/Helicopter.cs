 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public GameObject helicopter;
    public bool stopSpawn;
    public float spawnAni, spawnAraligi;

    // Start is called before the first frame update
    void Start()
    {
        stopSpawn = false;
        InvokeRepeating("Spawn", spawnAni, spawnAraligi);   
    }
    void Spawn()
    {
        Instantiate(helicopter, new Vector3(Random.Range(75f, 350f), 25f, Random.Range(65f, 330f)),Quaternion.identity);

        if (stopSpawn)
        {
            CancelInvoke("Spawn");
            
        }
    }
}
