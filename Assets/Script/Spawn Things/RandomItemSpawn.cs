using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawn : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<spawnPoints.Length; i++)
        {
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnPoints[i]);
        }
         
    }

}
