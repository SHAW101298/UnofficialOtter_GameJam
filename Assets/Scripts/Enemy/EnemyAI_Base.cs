using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyAI_Base : MonoBehaviour
{
    public EnemyController enemy;
    public NavMeshAgent agent;
    public Transform target;

    public bool canMove = true;
    public float distanceToAttack;
}
