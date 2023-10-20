using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    RaycastHit hit;
    public Camera hitCikisNoktasi;
    public GameObject itemAlert;
    public GameObject itemslot;
    //public GameObject silahslot;

    public SlotYonetimi slotYonetim;
    //public Silah_Slot_Yonetimi silahSlotYonetim;

    AudioSource oyunsesi;

    private void Start()
    {
        oyunsesi = GetComponent<AudioSource>();
        oyunsesi.Play();
    }
    void Update()
    {
        if (Physics.Raycast(hitCikisNoktasi.transform.position, hitCikisNoktasi.transform.forward, out hit, 4f))
        {
            if (hit.transform.gameObject.GetComponent<Item_Islemi>() != null)
            {
                itemAlert.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    slotYonetim.Slota_Item_Ekle(hit.transform.gameObject.GetComponent<Item_Islemi>().itemPrefab);
                    Destroy(hit.transform.gameObject);
                }
            }
            /*else if (hit.transform.gameObject.GetComponent<Silah_Slot_Islemi>() != null)
            {
                itemAlert.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    silahSlotYonetim.Slota_Item_Ekle(hit.transform.gameObject.GetComponent<Silah_Slot_Islemi>().itemPrefab);
                    Destroy(hit.transform.gameObject);
                }
            }*/
            else
            {
                itemAlert.SetActive(false);
            }
        } 
    }
}

