using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour


{
    //COOLDOWN
    public float cooldownTime = 2;

    private float nextFireTime = 0;

    //ANIMATION
    public AudioSource theFlash;

    Animator anim1;
 
    void Start()
    {
        anim1 = GetComponent<Animator>();
    }
 
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextFireTime = Time.time + cooldownTime;

                anim1.SetTrigger("Trigger");
                theFlash.Play();
            }
        }
    }
        
    
}
