using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDonumu : MonoBehaviour
{
 
    void Update()
    {
        transform.RotateAround(new Vector3(200f, 0, 200f), Vector3.right, 10f * Time.deltaTime);
    }
}
