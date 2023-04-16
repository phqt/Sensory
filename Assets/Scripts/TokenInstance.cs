using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TokenInstance : MonoBehaviour
{
    public AudioSource filmSound;
    public TextMeshProUGUI filmText;
    public int NumberOfFilm = 0;

    bool interactCooldown;

    //public PlayerFilmPickup player;

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

        interactCooldown = true;

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


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action && interactCooldown == true)
            {
                Instruction.SetActive(false);
                ObjectOnGround.SetActive(false);
                //ObjectOnHand.SetActive(true);
                //ThisTrigger.SetActive(false);
                Action = false;

                NumberOfFilm++;

                filmText.text = NumberOfFilm.ToString();

                //interactCooldown = false;
                //Invoke("interactCooldown", 2.0f);

                //playerInventory.FilmCollected();
                filmSound.Play();

            }
        }


    }
}