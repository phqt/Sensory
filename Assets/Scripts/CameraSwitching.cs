using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching: MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public float switchDuration = 5.0f;
    public int boxesToCollect = 3;

    private int boxesCollected = 0;
    private bool switching = false;
    private float switchTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (boxesCollected >= 1 && !switching)
        {
            switching = true;
            switchTimer = switchDuration;
            camera1.SetActive(false);
            camera2.SetActive(true);
        }

        if (switching)
        {
            switchTimer -= Time.deltaTime;

            if (switchTimer <= 0.0f)
            {
                switching = false;
                camera1.SetActive(true);
                camera2.SetActive(false);
                boxesCollected = 0;
            }
        }

        // Get the NumberOfFilm variable from the other script
        int ammoCount = GameObject.Find("Triggerpickup2").GetComponent<AmmoBox>().ammoCount;
        boxesCollected = ammoCount;
    }
}
