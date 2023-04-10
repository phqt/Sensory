using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource theSFX;

    void OnTriggerEnter(Collider other)
    {
        theSFX.Play();

    }
}
