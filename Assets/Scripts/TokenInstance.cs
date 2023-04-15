using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TokenInstance : MonoBehaviour
{
    public AudioSource filmSound;
    public TextMeshProUGUI displayScore;
    public int currentScore;



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
    //public bool Action = false;

    void Start()
    {
        GetComponent<TriggerAnimation>();
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
            //Action = true;
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        //Action = false;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //if (Action == true)
            //{
            currentScore++;
            Instruction.SetActive(false);
            ObjectOnGround.SetActive(false);
            //ObjectOnHand.SetActive(true);
            ThisTrigger.SetActive(false);
            //Action = false;

                

            //playerInventory.FilmCollected();
            filmSound.Play();

        }
        else
        {
            displayScore.text = currentScore.ToString();      
        }
    }


}

