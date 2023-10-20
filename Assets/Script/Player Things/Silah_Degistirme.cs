using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silah_Degistirme : MonoBehaviour
{
    public GameObject[] silahlar;
    public AudioSource Change;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponChange(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponChange(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponChange(2);
        }
    }

    void WeaponChange(int SiraNumarasi)
    {
        Change.Play();
        foreach (GameObject slh in silahlar)
        {
            slh.SetActive(false);
        }
        silahlar[SiraNumarasi].SetActive(true);
    }
}
