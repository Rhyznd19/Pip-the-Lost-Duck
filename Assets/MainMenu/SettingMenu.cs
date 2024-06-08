using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mixer;
    public GameObject SettingCanvas;
    public GameObject MainMenu;
    // Start is called before the first frame update
    public void ChangeMasterVolume()
    {
        mixer.SetFloat("Master", masterVol.value);
    }
    public void ChangeMusicVolume()
    {
        mixer.SetFloat("Ambient", musicVol.value);
    }
    public void ChangesfxVolume()
    {
        mixer.SetFloat("Sfx", sfxVol.value);
    }

    public void back()
    {
        SettingCanvas.SetActive(false);
        MainMenu.SetActive(true);
    }
}
