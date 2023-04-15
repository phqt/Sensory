using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
 
public class OnClickUICount : MonoBehaviour {
   
    
    public int currentScore;
    public TextMeshProUGUI displayScore;
   
 
    // Use this for initialization
    void Start () 
    { 
        currentScore = 3;
    }
 
 
    // Update is called once per frame
    void Update () 
    {  
        if (Input.GetMouseButtonDown(0))
        {
            currentScore--;
        }
        else
        {
            displayScore.text = currentScore.ToString();
        }
    }
 
    
}
