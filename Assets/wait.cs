using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wait : MonoBehaviour
{
    public float waitTime = 21f;
    void Start()
    {
        StartCoroutine(waitIntro());
    }
    IEnumerator waitIntro()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(1);
    }
}
