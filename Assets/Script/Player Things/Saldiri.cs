using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saldiri : MonoBehaviour
{
    Animator anim;
    public AudioSource SaldiriSesi;
    RaycastHit hit;
    public float Menzil;
    float GunTimer;
    public float KesmeHizi;
    public Camera cam;
    public ParticleSystem kanizi;
    public ParticleSystem wrenchizi;


    void Start()
    {
        anim = GetComponent<Animator>();  
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > GunTimer)
            {
                Kes();
                GunTimer = Time.time + KesmeHizi;
            }   
        }
    }

    void Kes()
    {
        anim.Play("saldirianimasyon");
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Menzil))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                SaldiriSesi.Play();
                Instantiate(kanizi, hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.GetComponent<Zombie>().HasarAl(20);
            }
            else
            {
                SaldiriSesi.Play();
                Instantiate(wrenchizi, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

    

    
}
