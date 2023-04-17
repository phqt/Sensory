using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiMixer;

    public void SetVolume (float volume)
    {
        audiMixer.SetFloat("volume", volume);
    }
}
