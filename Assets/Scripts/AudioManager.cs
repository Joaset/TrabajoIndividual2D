using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectsMixer;
    public AudioSource backgroundMusic, shoot, enemydead, dead, jump;
    public static AudioManager instance;
    public float masterVol, effectsVol;
    // public Slider masterSlider, effectslider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        // masterSlider.value = masterVol;
        // effectslider.value = effectsVol;
        // masterSlider.minValue = -80;
        // masterSlider.maxValue = -10;
        // effectslider.minValue = -80;
        // effectslider.maxValue = -10;
    }

    void Update()
    {
        MasterVolume();
        EffectsVolume();
    }

    public void MasterVolume()
    {
        musicMixer.SetFloat("masterVolumen", masterVol);
    }

    public void EffectsVolume()
    {
        effectsMixer.SetFloat("effectsVolumen", effectsVol);
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
