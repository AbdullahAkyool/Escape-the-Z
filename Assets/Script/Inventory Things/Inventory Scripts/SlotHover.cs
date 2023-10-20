using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    Color32 DefaultRenk = new Color32(92, 89, 89, 255);
    Color32 HoverRenk = new Color32(154, 146, 146, 255);

    public bool slotdolumu = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = HoverRenk;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = DefaultRenk;
    }

}
