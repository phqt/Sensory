using System.Collections;
using System.Collections.Generic;
using Mono.Reflection;
using UniGLTF.Extensions.VRMC_springBone;
using UnityEngine;
using Collider = UnityEngine.Collider;

public class InstructionEnter : MonoBehaviour
{

    public GameObject Instruction;
    //public Collider ThisTrigger;
    public GameObject thisTrigger;
    public GameObject filmRoll;

    public bool Action = false;


    void Start()
    {

        Instruction.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
    }



    void OnTriggerEnter(Collider other)
    {
            Instruction.SetActive(true);
            Action = true;
    }

    void OnTriggerExit(Collider collision)
    {
        //Instruction.SetActive(false);
        //Action = false;
        //ThisTrigger.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;
        this.thisTrigger.SetActive(true);
        Action = false;
    }

    void update()
    {
        Action = false;
        Instruction.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = true;

    }
}