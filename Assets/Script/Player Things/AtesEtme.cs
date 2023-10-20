using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AtesEtme : MonoBehaviour
{
    [Header("Genel Ayarlar")]
    RaycastHit hit;
    public bool AtesEdebilir;
    float GunTimer;
    public float TaramaHizi;
    public float Menzil;
    public Camera cam;


    [Header("Sesler")]
    public AudioSource AtesSesi;
    public AudioSource SarjorDegistirmeSesi;
    public AudioSource MermiBitisSesi;


    [Header("Efektler")]
    public ParticleSystem MuzzleFlash;
    public ParticleSystem mermiizi;
    public ParticleSystem kanizi;

    [Header("Diğer")]
    Animator anim;
    GameObject zombie;

    [Header("Sarjor Ayarları")]
    public int ToplamMermi;
    public int KalanMermi;
    public int SarjorKapasitesi;
    public TextMeshProUGUI ToplamMermi_text;
    public TextMeshProUGUI KalanMermi_text;
    public GameObject itemAlert;
 
    void Start()
    {
        anim = GetComponent<Animator>();
        ToplamMermi_text.text = ToplamMermi.ToString();
        KalanMermi_text.text = KalanMermi.ToString();
        zombie = GameObject.FindGameObjectWithTag("Enemy");
    }
    
    void Update()
    {

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 4f))
        {
            if (hit.transform.gameObject.tag == "AmmoBox")
            {
                itemAlert.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    ToplamMermi += 60;
                    ToplamMermi_text.text = ToplamMermi.ToString();
                    Destroy(hit.transform.gameObject);
                    itemAlert.SetActive(false);
                }
            }
        }


            if (Input.GetKey(KeyCode.Mouse0))
        {
            if (AtesEdebilir == true && Time.time > GunTimer && KalanMermi != 0)
            {
                Fire();
                GunTimer = Time.time + TaramaHizi;
            }
            if(KalanMermi==0)
            {
                MermiBitisSesi.Play();
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            if (KalanMermi < SarjorKapasitesi && ToplamMermi!=0)
            {
                int fark = SarjorKapasitesi - KalanMermi;

                if (ToplamMermi >= SarjorKapasitesi)
                {
                    ToplamMermi -= fark;
                    KalanMermi += fark;
                    
                }

                else if (ToplamMermi <= SarjorKapasitesi)
                {

                    int fazlalik=KalanMermi + ToplamMermi;
                    if (fazlalik > SarjorKapasitesi)
                    {
                        ToplamMermi = KalanMermi-SarjorKapasitesi;
                        KalanMermi = SarjorKapasitesi;
                    }
                    else
                    {
                        KalanMermi = fazlalik;
                        ToplamMermi = 0;
                    }
                    
                }
                KalanMermi_text.text = KalanMermi.ToString();
                ToplamMermi_text.text = ToplamMermi.ToString();

                anim.Play("sarjordegistirme");
            }
            
        }
    }

    void SarjorDegistir()
    {
        SarjorDegistirmeSesi.Play();
    }

    void Fire()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Menzil))
        {
            KalanMermi--;
            KalanMermi_text.text = KalanMermi.ToString();

            AtesSesi.Play();
            anim.Play("AtesEtmeAnimasyon");
            MuzzleFlash.Play();
         
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                Instantiate(kanizi, hit.point, Quaternion.LookRotation(hit.normal));
                hit.transform.gameObject.GetComponent<Zombie>().HasarAl(40);
            }
            else
            {
                Instantiate(mermiizi, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }  
    }

}