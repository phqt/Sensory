using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quitGame : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
