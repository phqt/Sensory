using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollidePlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider c){
         if(c.gameObject.name == "Player")
            Debug.Log ("Player triggered");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
            
         
     }
}
