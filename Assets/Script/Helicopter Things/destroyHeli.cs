using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyHeli : MonoBehaviour
{
    AudioSource helicopterSound;
    
    void Start()
    {
        Destroy(this.gameObject, 20f);
        helicopterSound = GetComponent<AudioSource>();
    }
}
