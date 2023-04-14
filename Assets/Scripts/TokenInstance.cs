using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenInstance : MonoBehaviour
{
    public AudioSource filmSound;

    //private void Update()
    //{
    //    PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

    //    if (playerInventory != null)
    //    {
    //        playerInventory.FilmCollected();
    //        filmSound.Play();
    //        gameObject.SetActive(false);
    //    }
    //}

    public GameObject Instruction;
    public GameObject ThisTrigger;
    public GameObject ObjectOnGround;
    //public GameObject ObjectOnHand;
    public bool Action = false;

    void Start()
    {
        Instruction.SetActive(false);
        ThisTrigger.SetActive(true);
        ObjectOnGround.SetActive(true);
        //ObjectOnHand.SetActive(false);

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
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                Instruction.SetActive(false);
                ObjectOnGround.SetActive(false);
                //ObjectOnHand.SetActive(true);
                ThisTrigger.SetActive(false);
                Action = false;

                //playerInventory.FilmCollected();
                //filmSound.Play();

            }
        }

    }
}
