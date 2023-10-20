using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Player : MonoBehaviour
{
    public float maxHealth, maxThirst, maxHunger,minHealth;
    public float thirstArtisHizi, hungerArtisHizi;
    public float health, thirst, hunger;
    public bool dead;

    private GameObject HealthSlider;
    private GameObject HungerSlider;
    private GameObject ThirstSlider;

    public GameObject DeadScreen;

    public AudioSource hurt;

    public void Start()
    {
        health = maxHealth;
        HealthSlider = GameObject.FindGameObjectWithTag("HealthSlider");
        HungerSlider = GameObject.FindGameObjectWithTag("HungerSlider");
        ThirstSlider = GameObject.FindGameObjectWithTag("ThirstSlider");
    }

    public void Update()
    {
        HealthSlider.GetComponent<Slider>().value = health / maxHealth;
        HungerSlider.GetComponent<Slider>().value = hunger / maxHunger;
        ThirstSlider.GetComponent<Slider>().value = thirst / maxThirst; 

        if (!dead)
        {
            hunger += hungerArtisHizi * Time.deltaTime;
            thirst += thirstArtisHizi * Time.deltaTime;
        }
        if (thirst >= maxThirst || hunger >= maxHunger)
        {
            Die();
        }


    }

    public void HasarAl(float alinanhasar)
    {
        hurt.Stop();
        health -= alinanhasar;
        hurt.Play();
        if (health <= minHealth)
        {
            Die();
        }
    }

    public void Die()
    {
        dead = true;
        DeadScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
    }
}
