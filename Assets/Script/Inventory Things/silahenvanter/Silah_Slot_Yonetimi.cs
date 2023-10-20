using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silah_Slot_Yonetimi : MonoBehaviour
{

    [SerializeField] private List<GameObject> SlotlarinTumu;
    //public PlayerHealth playerhealth;

    void Start()
    {

    }

    public void Slota_Item_Ekle(Transform gelenobje)
    {
        Transform gelenobjeyiolustur = Instantiate(gelenobje, Vector3.zero, Quaternion.identity);

        foreach (var item in SlotlarinTumu)
        {
            if (!item.GetComponent<SlotHover>().slotdolumu)
            {
                gelenobjeyiolustur.transform.SetParent(item.transform);
                gelenobjeyiolustur.transform.localPosition = new Vector3(0, 0, 0);
                item.GetComponent<SlotHover>().slotdolumu = true;
                break;
            }
            else
            {
                continue;
            }
        }
    }
}
