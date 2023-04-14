using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfFilm { get; private set; }

    public UnityEvent<PlayerInventory> OnFilmCollected;

    public void FilmCollected()
    {
        NumberOfFilm++;
        OnFilmCollected.Invoke(this);
    }
}
