using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackGroundPref = "BackGroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";

    private float backgroundFloat, soundEffectsFloat;

    public AudioSource backgroundSound;
    public AudioSource[] soundEffectsSound;

    void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackGroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        backgroundSound.volume = backgroundFloat;

        for (int i = 0; i < soundEffectsSound.Length; i++)
        {
            soundEffectsSound[i].volume = soundEffectsFloat;
        }
    }
}
