using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public int EnemyHealth = 10;
    public GameObject TheEnemy;
    public int StatusCheck;

    void DamageEnemy (int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }


    void Update()
    {
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            StatusCheck = 2;
            TheEnemy.SetActive(false);
        }
    }
}
