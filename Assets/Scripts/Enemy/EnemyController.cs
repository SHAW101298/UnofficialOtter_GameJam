using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public EnemyAI_Base ai;
    public EnemyStats stats;
    public Animator anim;

    [Header("Graphical")]
    public SpriteRenderer bodyImage;
    public Color originalColor;
    public Color hurtColor;
    bool recentlyTakenDamage;
    float hurtTimer;

    public bool isDead;


    public void TakeDamage(float damage)
    {
        isDead = stats.TakeDamage(damage);

        if(isDead == false)
        {
            recentlyTakenDamage = true;
            anim.SetTrigger("Hurt");
            ai.canMove = false;
            ai.agent.SetDestination(transform.position);
            ai.agent.velocity = Vector3.zero;
            hurtTimer = 0;
        }
        else
        {
            tag = "Untagged";
            
            recentlyTakenDamage = false;
            ai.target = null;
            ai.canMove = false;
            ai.agent.SetDestination(transform.position);
            ai.agent.velocity = Vector3.zero;
            Destroy(ai.agent);
            WaveManager.ins.RemoveEnemyFromList(this);
            anim.SetTrigger("Death");
        }
    }

    private void Update()
    {
        if(recentlyTakenDamage == true)
        {
            hurtTimer += Time.deltaTime;
            bodyImage.color = Color.Lerp(hurtColor, originalColor, hurtTimer);

            if(hurtTimer >= 1)
            {
                hurtTimer = 0;
                recentlyTakenDamage = false;
                bodyImage.color = originalColor;
            }
        }
    }
    public void ANIM_Death()
    {
        Destroy(gameObject);
    }
    public void ANIM_EndHurt()
    {
        ai.canMove = true;
    }
}
