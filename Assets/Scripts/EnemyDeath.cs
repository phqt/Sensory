using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour
{
    public int EnemyHealth = 10;
    public GameObject TheEnemy;
    //public int StatusCheck;

    public GameObject EnemyGoal;
    NavMeshAgent EnemyAgent;
    public static bool isChasing;
    public static bool isAlive;

    private void Start()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();
    }


    void DamageEnemy(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }


    void Update()
    {
        if (isChasing == false)
        {
            TheEnemy.GetComponent<Animator>().Play("Orc Idle");
            isAlive = true;
        }

            if (isChasing == true && EnemyHealth >= 0 && isAlive == true)
            {
                
                TheEnemy.GetComponent<Animator>().Play("Sad Walk");
                EnemyAgent.SetDestination(EnemyGoal.transform.position);
            }


            if (EnemyHealth <= 0)
            {
            //StatusCheck = 2;
                isAlive = false;
                EnemyAgent.Stop();
                TheEnemy.GetComponent<Animator>().Play("Stunned");
                StartCoroutine(waitDeath());
            }

            IEnumerator waitDeath()
            {
                yield return new WaitForSeconds(3f);
                TheEnemy.SetActive(false);
            }

        }
    }
