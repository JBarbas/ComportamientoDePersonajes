using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    
    public Slider slider;
    public Text txtVolume;
    private float volume;

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        if ((slider.value * 100) <= 0.01)
        {
            txtVolume.text = "0";
           
        }else{
            volume = slider.value * 100;
            txtVolume.text = "" + (int) volume;
        }

    }
}
