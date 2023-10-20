using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot_Item : MonoBehaviour
{

    [SerializeField] private Items ItemTable;
    public Image itemIcon;

    private GameObject player;

    void Start()
    {
        itemIcon.sprite = ItemTable.itemicon;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Item_Kullan()
    {

        if (ItemTable.itemname == "FirstAidKit")
        {
             if (player.GetComponent<Health_Player>().health < player.GetComponent<Health_Player>().maxHealth)
              {
                player.GetComponent<Health_Player>().health += (player.GetComponent<Health_Player>().maxHealth - player.GetComponent<Health_Player>().health);
                  Destroy(gameObject);
                GetComponentInParent<SlotHover>().slotdolumu = false;
            }
              else
              {
                 //canvas ile medkit kullanmaya gerek yok yazılacak
              }
        }

        else if(ItemTable.itemname == "Konserve")
        {
            if (player.GetComponent<Health_Player>().hunger>25)
            {
                player.GetComponent<Health_Player>().hunger -= 25;
                Destroy(gameObject);
                GetComponentInParent<SlotHover>().slotdolumu = false;
            }
            else
            {
                //canvas ile konserve kullanmaya gerek yok yazılacak
            } 
        }

        else if (ItemTable.itemname == "Water")
        {
            if (player.GetComponent<Health_Player>().thirst> 25)
            {
                player.GetComponent<Health_Player>().thirst -= 25;
                Destroy(gameObject);
                GetComponentInParent<SlotHover>().slotdolumu = false;
            }
            else
            {
                //canvas ile su kullanmaya gerek yok yazılacak
            }   
        } 
    }

    public void Item_Sil()
    {
        GetComponentInParent<SlotHover>().slotdolumu = false;
        //Debug.Log(ItemTable.itemname + "Silindi");
        Destroy(gameObject);
    }
}
