using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    private void Start()
    {
        AudioListener.volume = 0.1f;
    }
    public void setVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
