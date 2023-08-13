using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float damage;

    EnemyController enemy;

    private void Start()
    {
        enemy = GetComponent<EnemyController>();
    }

    public bool TakeDamage(float value)
    {
        health -= value;
        if(health <=0)
        {
            return true;
        }
        return false;
    }
}
