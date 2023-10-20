using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Silah_Slot_Item : MonoBehaviour
{

    [SerializeField] private Items ItemTable;
    public Image itemIcon;

    public GameObject[] silahlar;

    /*private GameObject silahsiz;
    private GameObject wrenchli;
    private GameObject silahli;*/


    void Start()
    {
        itemIcon.sprite = ItemTable.itemicon;

        /*silahsiz = GameObject.FindGameObjectWithTag("silahsiz");
        wrenchli = GameObject.FindGameObjectWithTag("wrenchli");
        silahli  = GameObject.FindGameObjectWithTag("silahli");*/
    }

    void Update()
    {
        
    }

    public void Item_Kullan()
    {
        //Debug.Log(ItemTable.itemname + "Kullanıldı");

        if (ItemTable.itemname == "Ak47")
        {
            /*silahsiz.SetActive(false);
            wrenchli.SetActive(false);
            silahli.SetActive(true);*/

            silahlar[0].gameObject.SetActive(false);
            silahlar[1].gameObject.SetActive(false);
            silahlar[2].gameObject.SetActive(true);

           //Debug.Log(silahlar[2].tag);
        }
        else if (ItemTable.itemname == "Wrench")
        {

           /* silahsiz.SetActive(false);
            wrenchli.SetActive(true);
            silahli.SetActive(false);*/

            //Debug.Log(silahlar[1].tag);

              silahlar[0].gameObject.SetActive(false);
              silahlar[1].gameObject.SetActive(true);
              silahlar[2].gameObject.SetActive(false);
        }
        else if (ItemTable.itemname == "Bos")
        {
            silahlar[0].gameObject.SetActive(true);
            silahlar[1].gameObject.SetActive(false);
            silahlar[2].gameObject.SetActive(false);

        }

            GetComponentInParent<SlotHover>().slotdolumu = true;
        
    }

    public void Item_Sil()
    {
        /*GetComponentInParent<SlotHover>().slotdolumu = false;
        Debug.Log(ItemTable.itemname + "Silindi");
        Destroy(gameObject);*/
    }
}
