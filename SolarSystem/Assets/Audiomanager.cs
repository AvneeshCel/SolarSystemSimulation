using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager instance;

    [SerializeField] AudioMixer mixer;
    
    public const string MUSIC_KEY = "musicVLM";
    public const string SFX_KEY = "sfxVLM";
    public const string MASTER_KEY = "masterVLM";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1f);

        mixer.SetFloat(SettingValue.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(SettingValue.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
        mixer.SetFloat(SettingValue.MIXER_MASTER, Mathf.Log10(masterVolume) * 20);
    }

}
