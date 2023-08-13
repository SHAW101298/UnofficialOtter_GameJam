using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunSlam : AbilityBase
{
    public float slamDistance;
    public float damageMultiplier;
    public float stunTime;
    public LayerMask enemyLayer;
    public GameObject stunIcon;
    public GameObject particles;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Recharge();
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (onCooldown == false && player.blockMovement == false)
            {
                Slam();
            }
        }
    }

    void Slam()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, slamDistance, Vector2.zero, 0.1f,enemyLayer);
        foreach(RaycastHit2D hit in hits)
        {
            EnemyController enemy = hit.collider.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(player.stats.ReadDamage() * damageMultiplier);
            GameObject temp = Instantiate(stunIcon);
            temp.transform.SetParent(enemy.transform);
            Enemy_StunState stunState = temp.GetComponent<Enemy_StunState>();
            stunState.stunTime = stunTime;
            stunState.Activate();
        }
        GameObject temp_prt = Instantiate(particles, transform, false);
        temp_prt.GetComponent<AutoDestroyScript>().destroyTime = 1.5f;
        onCooldown = true;
    }
}
