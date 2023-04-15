using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneSwitch : MonoBehaviour

{


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            SceneManager.LoadScene("WakeUp");


        }
    }
}
