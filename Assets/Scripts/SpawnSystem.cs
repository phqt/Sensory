using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject dudeOne;
    public GameObject dudeTwo;
    public GameObject dudeThree;
    public GameObject dudeFour;
    public GameObject dudeFive;

    private GameObject activeDude;

    // Start is called before the first frame update
    void Start()
    {
        // Activate the first dude
        activeDude = dudeOne;
        activeDude.SetActive(true);

        // Deactivate the other dudes
        dudeTwo.SetActive(false);
        dudeThree.SetActive(false);
        dudeFour.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the active dude is inactive
        if (!activeDude.activeSelf)
        {
            // Determine the next dude to activate
            if (activeDude == dudeOne)
            {
                activeDude = dudeTwo;
            }
            else if (activeDude == dudeTwo)
            {
                activeDude = dudeThree;
            }
            else if (activeDude == dudeThree)
            {
                activeDude = dudeFour;
            }
            else if (activeDude == dudeFour)
            {
                //activeDude = dudeOne;
                activeDude = dudeFive;
            }

            else if (activeDude == dudeFive)
            {
                return;
            }

            // Activate the next dude
            activeDude.SetActive(true);
        }

        // Deactivate the other dudes
        if (activeDude == dudeOne)
        {
            dudeTwo.SetActive(false);
            dudeThree.SetActive(false);
            dudeFour.SetActive(false);
            dudeFive.SetActive(false);
        }
        else if (activeDude == dudeTwo)
        {
            dudeOne.SetActive(false);
            dudeThree.SetActive(false);
            dudeFour.SetActive(false);
            dudeFive.SetActive(false);
        }
        else if (activeDude == dudeThree)
        {
            dudeOne.SetActive(false);
            dudeTwo.SetActive(false);
            dudeFour.SetActive(false);
            dudeFive.SetActive(false);
        }
        else if (activeDude == dudeFour)
        {
            dudeOne.SetActive(false);
            dudeTwo.SetActive(false);
            dudeThree.SetActive(false);
            dudeFive.SetActive(false);
        }
        else if (activeDude == dudeFive)
        {
            dudeOne.SetActive(false);
            dudeTwo.SetActive(false);
            dudeThree.SetActive(false);
            dudeFour.SetActive(false);
        }
    }
}
