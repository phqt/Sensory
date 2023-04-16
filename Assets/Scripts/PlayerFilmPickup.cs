using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFilmPickup : MonoBehaviour
{
    public GameObject Trigger;

    public TokenInstance trigScript;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            trigScript.Update();
        }
    }
}
