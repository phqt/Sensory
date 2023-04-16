using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerAnimation : MonoBehaviour


{
    //COOLDOWN
    public float cooldownTime = 2;

    private float nextFireTime = 0;

    //ANIMATION
    public AudioSource theFlash;
    bool playAnim;
    Animator anim1;
    
    //SCORE COUNTER
    PlayerInventory playerInventory;

    //public int currentScore;
    public TextMeshProUGUI displayScore;
    
    
 
    public void Start()
    {
        anim1 = GetComponent<Animator>();
        playAnim = false;
        //currentScore = 3;
        
    }
 
    public void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextFireTime = Time.time + cooldownTime;

                anim1.SetTrigger("Trigger");
                theFlash.Play();
                playAnim = true;
                //currentScore--;
            }
            else
            {
                //displayScore.text = currentScore.ToString();
            }
            //if (currentScore == 0) 
            //{
                //currentScore = 0;
                //playAnim = false;
            //}   
            
            
        }
    }

        //if (playAnim = true)
        //{
        //    playerInventory.GetComponent<PlayerInventory>();
        //
        //    playerInventory.FilmCollected();
        //}
        
}
     
    

