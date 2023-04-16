using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoBox : MonoBehaviour
{
    public int ammoAmount = 10; // The amount of ammo the box contains

    private bool collected = false; // Whether the box has already been collected

    public AudioSource filmSound;
    public TextMeshProUGUI filmText;
    public GameObject Instruction;
    public GameObject ThisTrigger;
    public GameObject ObjectOnGround;
    public bool Action = false;

    private bool hasInteracted = false;
    public Collider ammoCollider;
    private bool isInRange = false;

    void Start()
    {
        Instruction.SetActive(false);
        ThisTrigger.SetActive(true);
        ObjectOnGround.SetActive(true);
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
        ThisTrigger.SetActive(false);
    }

    public void CollectAmmo(AmmoSystem ammoSystem)
    {
        if (!collected)
        {
            ammoSystem.AddAmmo(ammoAmount);
            collected = true;
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    ObjectOnGround.SetActive(false);
        //}

        //if (Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        //{
        //    if (ThisTrigger.Bounds.Contains(transform.position))
        //    {
        //        ThisTrigger.SetActive(false);
        //        hasInteracted = true;
        //    }
        //}
            if (isInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E))
            {
                // check if the player is within the ammo box collider
                if (ammoCollider.bounds.Intersects(GetComponent<Collider>().bounds))
                {

                    // disable the collider to prevent getting more ammo and make the ammo box invisible
                    ammoCollider.enabled = false;
                    GetComponent<Renderer>().enabled = false;

                    // set flag to track interaction with this ammo box
                    hasInteracted = true;
                }
            }

        }
    }