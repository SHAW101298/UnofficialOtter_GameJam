using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Melee : EnemyAI_Base
{
    Vector3 dir;
    public float roamDistance = 2f;

    private void Update()
    {
        if (canMove == false)
            return;
        if (target == null)
            return;
        float distance = Vector3.Distance(transform.position, target.position);
        Vector3 randomPoint = Vector3.zero;
        agent.SetDestination(target.position + randomPoint);
        dir = target.position - transform.position;
        dir = dir.normalized;
        if (distance <= distanceToAttack)
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
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if (dir.x > 0)
            {
                enemy.anim.SetFloat("Blend", 1);
            }
            else
            {
                enemy.anim.SetFloat("Blend", 0.6f);
            }
        }
        else
        {
            if (dir.y > 0)
            {
                enemy.anim.SetFloat("Blend", 0.3f);
            }
            else
            {
                enemy.anim.SetFloat("Blend", 0);
            }
        }
    }

    public void ANIM_EndAttack()
    {
        canMove = true;
    }
    public void ANIM_DamageTime()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= distanceToAttack + 0.5f)
        {
            PlayerController.ins.TakeDamage(enemy.stats.damage);
        }
    }

    Vector3 RandomPointAroundPlayer()
    {
        Vector2 point;
        point = Random.insideUnitCircle * roamDistance;
        return point;
    }
}
