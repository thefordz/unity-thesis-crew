using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    [Header("Sound Manage")]
    public AudioMixer theMixer;
    public Slider masterSlider, musicSlider, sfxSlider;
    public const string MIXER_Master = "MasterVol";
    public const string MIXER_Music = "MusicVol";
    public const string MIXER_SFX = "SFXVol";

    void Awake() {
        masterSlider.onValueChanged.AddListener(SetMasterVol);
        musicSlider.onValueChanged.AddListener(SetMusicVol);
        sfxSlider.onValueChanged.AddListener(SetSfxVol);
    }


    void Start(){
        masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY,1f);
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY,1f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY,1f);
    }
    
     void OnDisable() {
        PlayerPrefs.SetFloat(AudioManager.MASTER_KEY, masterSlider.value);
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }

    public void SetMasterVol(float value){
        theMixer.SetFloat(MIXER_Master, MathF.Log10(value)*20);
         PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }

    public void SetMusicVol(float value){
        theMixer.SetFloat(MIXER_Music, MathF.Log10(value)*20);
         PlayerPrefs.SetFloat("MusicVol", musicSlider.value);

    }

    public void SetSfxVol(float value) {
         //sfxLabel.text = (sfxSlider.value*100).ToString();
        theMixer.SetFloat(MIXER_SFX, MathF.Log10(value)*20);
        // theMixer.SetFloat("SfxVol", sfxSlider.value);
         PlayerPrefs.SetFloat("SfxVol", sfxSlider.value);
    }

}
