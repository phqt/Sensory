using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollidePlayer : MonoBehaviour
{
    public float waitTime = 19f;
    public float oneSec = 1f;

    void OnTriggerEnter(Collider c){
         if(c.gameObject.name == "Player")
            Debug.Log ("Player triggered");
        SceneManager.LoadScene("death");

        // StartCoroutine("waitDeath");
    }



    //IEnumerator waitDeath()
    //{
        //SceneManager.LoadScene("death");
        //yield return new WaitForSeconds(waitTime);
        //SceneManager.LoadScene("SampleScene");
        //StartCoroutine(waitOne());

    //}


    //IEnumerator waitOne()
    //{
    //    yield return new WaitForSeconds(oneSec);
    //    SceneManager.LoadScene(2);
    //}
}

