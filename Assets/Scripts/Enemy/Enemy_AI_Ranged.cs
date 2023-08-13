using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI_Ranged : EnemyAI_Base
{
    public GameObject projectilePrefab;
    public float projectileSpeed;
    Vector3 dir;

    private void Update()
    {
        if (canMove == false)
            return;
        if (target == null)
            return;
        agent.SetDestination(target.position);
        float distance = Vector3.Distance(transform.position, target.position);
        dir = target.position - transform.position;
        dir = dir.normalized;
        if(distance <= distanceToAttack)
        {
            enemy.anim.SetTrigger("Attack");
            agent.SetDestination(transform.position);
            agent.velocity = Vector3.zero;
            canMove = false;
        }
        RotateTowardsWalkDirection();
    }
    void RotateTowardsWalkDirection()
    {
        if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if(dir.x > 0)
            {
                enemy.anim.SetFloat("Blend",1);
            }
            else
            {
                enemy.anim.SetFloat("Blend", 0.6f);
            }
        }
        else
        {
            if(dir.y > 0)
            {
                enemy.anim.SetFloat("Blend", 0.3f);
            }
            else
            {
                enemy.anim.SetFloat("Blend",0);
            }
        }
    }

    public void ANIM_EndAttack()
    {
        canMove = true;
    }

    public void ANIM_ShootProjectile()
    {
        GameObject go = Instantiate(projectilePrefab);
        go.transform.position = transform.position;
        Enemy_Projectile proj = go.GetComponent<Enemy_Projectile>();
        dir = target.position - transform.position;
        dir = dir.normalized;
        proj.flyDirection = dir;
        proj.damage = enemy.stats.damage;
        proj.speed = projectileSpeed;
        go.GetComponent<Rigidbody2D>().AddForce((dir * projectileSpeed) / 100);
        //Debug.Log("Projectile Shot");
    }


}
