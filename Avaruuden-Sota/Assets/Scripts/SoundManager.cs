using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update

    void Start()
    {   // Tarkistetaan, onko PlayerPrefsissa "musicVolume" avainta 
        if (!PlayerPrefs.HasKey("musicVolume"))

        {   // Jos avainta ei ole, asetetaan oletusarvo 1 joka on maksimi arvo
            PlayerPrefs.SetFloat("musicVolume", 1);

             //Tässä ladataan asetukset, että mitä muutoksia ollaan tehty
            Load();
        }
        else
        {   //Jos avain "musicVolume" on olemassa, ladataan asetukset
            Load();
        }
    }
    // Vaihdetaan äänenvoimakkuutta sliderin mukaan
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; // Määritellään uusi äänenvoimakkuus
        Save(); //Tallennetaan uusi äänenvoimakkuus
    }
    // Ladataan PlayerPrefsista tallennettu äänenvoimakkuus ja asetetaan sliderin arvoksi

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    // Tallennetaan äänenvoimakkuuden arvo PlayerPrefsiin
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
