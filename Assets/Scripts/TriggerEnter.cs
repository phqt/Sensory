using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    public GameObject element;
    public GameObject mainCam;

    void OnTriggerEnter(Collider other)
    {
        element.SetActive(true);
        mainCam.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        element.SetActive(false);
        mainCam.SetActive(true);
    }
}
