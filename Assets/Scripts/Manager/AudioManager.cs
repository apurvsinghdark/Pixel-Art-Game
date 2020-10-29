using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string BackGroundPref = "BackGroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    private int firstPlayInt;

    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;

    public AudioSource backgroundSound;
    public AudioSource[] soundEffectsSound;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt == 0)
        {
            backgroundFloat = 0.25f;
            soundEffectsFloat = 0.25f;

            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;

            PlayerPrefs.SetFloat(BackGroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsFloat);

            firstPlayInt = 1;
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackGroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(BackGroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundSound.volume = backgroundSlider.value;

        for(int i = 0; i < soundEffectsSound.Length; i++)
        {
            soundEffectsSound[i].volume = soundEffectsSlider.value;
        }
    }   
}
