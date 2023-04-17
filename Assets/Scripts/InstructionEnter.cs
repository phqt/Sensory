using System.Collections;
using System.Collections.Generic;
using Mono.Reflection;
using UniGLTF.Extensions.VRMC_springBone;
using UnityEngine;
using Collider = UnityEngine.Collider;

public class InstructionEnter : MonoBehaviour
{
    public int ammoAmount = 10;

    public GameObject Instruction;
    //public Collider ThisTrigger;
    public GameObject thisTrigger;
    public GameObject filmRoll;
    public AudioSource filmSound;
    public bool Action;
    public bool inRange;


    void Start()
    {

        Instruction.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
        thisTrigger.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        inRange = false;
        thisTrigger.SetActive(true);
        //Instruction.SetActive(false);
    }

    public void CollectAmmo(AmmoSystem ammoSystem)
    {
        if (!Action)
        {
            ammoSystem.AddAmmo(ammoAmount);
            Action = true;
        }
    }


    void Update()
    {
        //Instruction.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
        thisTrigger.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E) && inRange == true)
        {

            Instruction.SetActive(false);
            filmRoll.SetActive(false);
            Action = true;
            filmSound.Play();
            thisTrigger.SetActive(false);
            this.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {

            //this.GetComponent<BoxCollider>().enabled = true;
            Action = false;
            thisTrigger.SetActive(true);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }

}