using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordCollider : MonoBehaviour
{
    public PlayerStats stats;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            float damage = stats.ReadDamage();
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
        }
    }
}
