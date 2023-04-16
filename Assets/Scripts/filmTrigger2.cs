using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class filmTrigger2 : MonoBehaviour
{
    public int ammoAmount = 10; // The amount of ammo the box contains

    private bool collected = false; // Whether the box has already been collected

    public AudioSource filmSound;
    public TextMeshProUGUI filmText;
    public GameObject Instruction;
    public GameObject ThisTrigger;
    public GameObject FilmObject;
    public bool Action = false;

    private bool hasInteracted = false;

    void Start()
    {
        Instruction.SetActive(false);
        ThisTrigger.SetActive(true);
        FilmObject.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            FilmObject.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        //{
        //    if (ThisTrigger.Bounds.Contains(transform.position))
        //    {
        //        ThisTrigger.SetActive(false);
        //        hasInteracted = true;
        //    }
        //}
    }
}
