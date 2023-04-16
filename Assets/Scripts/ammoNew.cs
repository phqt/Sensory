using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ammoNew : MonoBehaviour
{
    public int ammoAmount = 1; // The amount of ammo the box contains
    public int ammoCount;

    private bool collected = false; // Whether the box has already been collected

    public AudioSource filmSound;
    public TextMeshProUGUI filmText;

    public GameObject ThisTrigger;
    public GameObject filmRoll;

    public bool Action = false;

    private bool hasInteracted = false;
    public Collider ammoCollider;
    private bool isInRange = false;



    public void CollectAmmo(AmmoSystem ammoSystem)
    {
        if (!collected)
        {
            ammoSystem.AddAmmo(ammoAmount);
            collected = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            filmSound.Play();
            ThisTrigger.SetActive(false);
        }
    }



    //public void pickCheck()
    //{

    //    if (isInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E) && Action == true)
    //    {

    //        // check if the player is within the ammo box collider
    //        if (ammoCollider.bounds.Intersects(GetComponent<Collider>().bounds))
    //        {

    //            // disable the collider to prevent getting more ammo and make the ammo box invisible


    //            ammoCount++;

    //            // set flag to track interaction with this ammo box
    //            hasInteracted = true;



    //        }



    //    }
    //}
}