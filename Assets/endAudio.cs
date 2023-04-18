using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endAudio : MonoBehaviour
{
    private int filmsCollected = 0;
    public AudioSource theSFX;

    void OnTriggerEnter(Collider other)
    {
        if (filmsCollected >= 5)
        {
            theSFX.Play();
        }
        int ammoCount = GameObject.Find("Player").GetComponent<AmmoSystem>().currentAmmo;
        filmsCollected = ammoCount;
    }
}
