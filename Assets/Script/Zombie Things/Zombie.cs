using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float ZombieHealth;
    bool ZombieDead;

    Animator anim;

    GameObject player;

    NavMeshAgent zombiNavMesh;
    float mesafe;
    public float kovalamaMesafesi;
    public float saldiriMesafesi;

    private bool isMoving;

    AudioSource zombisesi;
    Rigidbody rb;

    //public delegate void EnemyKilled();
    //public static event EnemyKilled OnEnemyKilled;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        zombiNavMesh= this.GetComponent<NavMeshAgent>();
        zombisesi = this.GetComponent<AudioSource>();
        
    }

    void Update()
    {   
        if (ZombieDead == true)
        {
            zombisesi.Stop();
            anim.SetBool("zombioldu", true);
            StartCoroutine(YokEt());
            isMoving = false;
        }
        else
        {
            mesafe = Vector3.Distance(this.transform.position, player.transform.position);

            if (mesafe <= kovalamaMesafesi)
            {
                //this.transform.LookAt(player.transform.position);
                zombiNavMesh.SetDestination(player.transform.position);
                anim.SetBool("zombiewalk", true);
                anim.SetBool("zombieattack", false);
                zombiNavMesh.isStopped = false;
                isMoving = true;
            }
            else
            {
                anim.SetBool("zombiewalk", false);
                anim.SetBool("zombieattack", false);
                zombiNavMesh.isStopped = true;
                rb.isKinematic = true;
                isMoving = false;
            }

            if (mesafe <= saldiriMesafesi)
            {
                anim.SetBool("zombiewalk", false);
                anim.SetBool("zombieattack", true);
                zombiNavMesh.isStopped = true;
                isMoving = false;
            }
            else
            {
                zombiNavMesh.isStopped = false;
                isMoving = true; 
            }
        }
    }
    IEnumerator YokEt()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);

       /* if (OnEnemyKilled != null)
        {
            OnEnemyKilled();
        }*/
    }
    
    public void HasarAl(float hasargucu)
    {
        ZombieHealth -= hasargucu;

        if (ZombieHealth <= 0)
        {
            anim.SetBool("zombiewalk", false);
            anim.SetBool("zombieattack", false);
            ZombieDead = true;
        }
        // ZombieHealth -= Random.Range(15, 25);
    }

    public void HasarVer()
    {
        player.GetComponent<Health_Player>().HasarAl(10);
    }
}
