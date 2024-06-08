using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditMenu : MonoBehaviour
{
    public GameObject SettingCanvas;
    public GameObject MainMenu;
    public void back()
    {
        SettingCanvas.SetActive(false);
        MainMenu.SetActive(true);
    }
}
