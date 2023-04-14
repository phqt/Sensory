using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
 
public class OnClickUICount : MonoBehaviour {
 
 
    public TextMeshProUGUI scoreUI;
   
    private int score;
 
 
    // Use this for initialization
    void Start () 
    { 
        score = 3;
        scoreUI.text = score.ToString();
        
    }
 
 
    // Update is called once per frame
    void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            score = score -1;
        }
        
    }
 
    
}
