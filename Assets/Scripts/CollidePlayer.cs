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
        StartCoroutine(waitDeath());
        SceneManager.LoadScene(4);
    }
    IEnumerator waitDeath()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(waitOne());

    }
    IEnumerator waitOne()
    {
        yield return new WaitForSeconds(oneSec);
        SceneManager.LoadScene(2);
    }
}

