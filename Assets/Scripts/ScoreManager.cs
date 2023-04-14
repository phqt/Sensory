using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI filmText;

    void Start()
    {
        filmText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateFilmText(PlayerInventory playerInventory)
    {
        filmText.text = playerInventory.NumberOfFilm.ToString();
    }

    

}
