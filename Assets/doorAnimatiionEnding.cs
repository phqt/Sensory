using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAnimatiionEnding : MonoBehaviour
{
    Animator animEnding;
    bool playEnding = false;
    public int currentAmmo = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AmmoSystem>();
        playEnding = false;
        animEnding = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAmmo == 3)
        {
            animEnding.SetTrigger("doorOpen");
            playEnding = true;
        }
    }
}
