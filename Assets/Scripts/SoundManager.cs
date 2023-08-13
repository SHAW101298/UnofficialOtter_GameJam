using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    #region
    public static SoundManager ins { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (ins != null && ins != this)
        {
            Destroy(gameObject);
        }
        else
        {
            ins = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    public float musicVolume = 0.25f;
    public float soundsVolume = 0.25f;
    public AudioSource musicSource;


    public void ChangeMusicVolume(Slider slider)
    {
        musicVolume = slider.value;
        musicSource.volume = musicVolume;
    }
    public void ChangeSoundVolume(Slider slider)
    {
        soundsVolume = slider.value;
    }
}
