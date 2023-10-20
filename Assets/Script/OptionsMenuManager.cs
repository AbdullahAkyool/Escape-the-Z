using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject kaliteayar;
    private void Start()
    {
       
    }
    public void OptionsButton()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void SetGraphic(int grap)
    {
        QualitySettings.SetQualityLevel(grap);
    }
    public void KaliteSecim(int kaliteindex)
    {

    }
}
