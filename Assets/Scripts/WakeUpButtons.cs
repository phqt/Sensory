using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpButtons : MonoBehaviour
{

    public GameObject mainmenuButton;
    public GameObject quitButton;

    void Start()
    {
    }

    void Update()
    {
        StartCoroutine("buttonActive");

    }

    IEnumerator buttonActive()
    {
        yield return new WaitForSeconds(16);
        mainmenuButton.SetActive(true);
        quitButton.SetActive(true);

    }
}
