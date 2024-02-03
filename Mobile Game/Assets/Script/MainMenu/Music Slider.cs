using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public Slider VoulumeSlider;
    public Slider musicSlider;

    [SerializeField]
    AudioMixer myAudiomixer;

    void start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            Load();
        }
        else
        {
            SetMusicVolume();
        }
    }

    void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music");
        musicSlider.value = PlayerPrefs.GetFloat("volume");
    }

    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        myAudiomixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("Music", musicVolume);
        PlayerPrefs.Save();
    }

    public void SetVolumeVolume()
    {
        float sliderVolume = VoulumeSlider.value;
        myAudiomixer.SetFloat("Volume", Mathf.Log10(sliderVolume) * 20);
        PlayerPrefs.SetFloat("Volume", sliderVolume);
        PlayerPrefs.Save();
    }
}
