using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    public GameObject EnemyGoal;
    NavMeshAgent EnemyAgent;
    public GameObject Enemy;
    public static bool isChasing;

    void Start()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();

    }


    void Update()
    {
        if (isChasing == false)
        {
            Enemy.GetComponent<Animator>().Play("Orc Idle");
        }

        else
        {
            Enemy.GetComponent<Animator>().Play("Standing Torch Walk Forward");
            EnemyAgent.SetDestination(EnemyGoal.transform.position);
        }
    }
}
