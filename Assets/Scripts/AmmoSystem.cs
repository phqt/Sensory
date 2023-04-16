using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AmmoSystem : MonoBehaviour
{
    public GameObject Instruction;
    //public GameObject ObjectOnGround;


    public int maxAmmo = 50; // The maximum amount of ammo the player can carry
    public int startingAmmo = 10; // The starting amount of ammo the player has
    public float interactDistance = 2f; // The distance at which the player can interact with the ammo box
    public KeyCode interactKey = KeyCode.E; // The key the player needs to hold to interact with the ammo box
    public AudioSource filmSound;

    public TextMeshProUGUI ammoText; // The UI text that displays the player's ammo count

    private int currentAmmo; // The current amount of ammo the player has

    private void Start()
    {
        Instruction.SetActive(false);
        //ObjectOnGround.SetActive(true);

        currentAmmo = startingAmmo;
        UpdateAmmoText();
    }

    private void Update()
    {

        if (Input.GetKeyDown(interactKey))
        {
            Instruction.SetActive(false);
            filmSound.Play();
            //ObjectOnGround.SetActive(false);


            // Check if the player is within the collider of an ammo box
            Collider[] colliders = Physics.OverlapSphere(transform.position, interactDistance);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("AmmoBox"))
                {
                    // Get the AmmoBox component from the collider and call its CollectAmmo method
                    AmmoBox ammoBox = collider.GetComponent<AmmoBox>();
                    if (ammoBox != null)
                    {
                        ammoBox.CollectAmmo(this);
                    }
                }
            }
        }
    }

    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Min(currentAmmo + amount, maxAmmo);
        UpdateAmmoText();
    }

    public void UpdateAmmoText()
    {
        ammoText.text = currentAmmo + " / " + maxAmmo;
    }
}