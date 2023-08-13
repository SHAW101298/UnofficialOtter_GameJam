using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : AbilityBase
{
    public float dashTime;
    public float dashForce;
    public bool isDashing;

    


    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        Recharge();
        /*
        if(Input.GetKeyDown(KeyCode.LeftShift) )
        {
            if(onCooldown == false && player.dir != Vector2.zero && player.blockMovement == false)
            {
                isDashing = true;
                player.blockMovement = true;
                player.isInvulnerable = true;
            }
        }
        */
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (onCooldown == false && player.dir != Vector2.zero)
            {
                isDashing = true;
                player.blockMovement = true;
                player.isInvulnerable = true;
                player.animator.Play("Move Tree");
                icon.fillAmount = 0;
            }
        }


    }
    private void FixedUpdate()
    {
        if (isDashing == true)
        {
            timer += Time.deltaTime;
            player.rb.AddForce(dashForce * player.dir);

            if (timer >= dashTime)
            {
                isDashing = false;
                timer = 0;
                onCooldown = true;
                player.isInvulnerable = false;
                player.blockMovement = false;
                
            }
        }
    }
}
