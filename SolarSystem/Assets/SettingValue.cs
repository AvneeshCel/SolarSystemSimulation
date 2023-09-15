using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingValue : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Slider masterSlider;


    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";
    public const string MIXER_MASTER = "MasterVolume";

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(Audiomanager.MUSIC_KEY, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(Audiomanager.SFX_KEY, 1f);
        masterSlider.value = PlayerPrefs.GetFloat(Audiomanager.MASTER_KEY, 1f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(Audiomanager.MASTER_KEY, masterSlider.value);
        PlayerPrefs.SetFloat(Audiomanager.SFX_KEY, sfxSlider.value);
        PlayerPrefs.SetFloat(Audiomanager.MUSIC_KEY, musicSlider.value);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
    
    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }
    
    public void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }

 
}
