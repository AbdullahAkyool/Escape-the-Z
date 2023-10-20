using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DefaultItem", menuName ="Item/Yeni Item Olustur")]

public class Items : ScriptableObject
{
    public string itemname;
    public Sprite itemicon;
}
