using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_StunState : MonoBehaviour
{
    EnemyController me;
    public float stunTime;
    float timer;
    public GameObject stunIcon;

    public void Activate()
    {
        me = GetComponentInParent<EnemyController>();
        if(me.isDead == true)
        {
            return;
        }
        me.ai.agent.velocity = Vector3.zero;
        me.ai.agent.SetDestination(transform.position);
        me.ai.canMove = false;
        me.anim.SetTrigger("Stun");
        me.anim.SetBool("Stunned",true);
    }
    // Update is called once per frame
    void Update()
    {
        if (me.isDead == false)
        {
            timer += Time.deltaTime;
            me.ai.canMove = false;
            me.ai.agent.velocity = Vector3.zero;
            me.ai.agent.SetDestination(transform.position);
            if (timer >= stunTime)
            {
                me.ai.canMove = true;
                me.anim.SetTrigger("ExitStun");
                me.anim.SetBool("Stunned", false);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
