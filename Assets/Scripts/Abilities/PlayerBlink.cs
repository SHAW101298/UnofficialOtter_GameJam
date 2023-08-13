using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlink : MonoBehaviour
{
    public string abilityName;
    public string description;

    float timer;
    public bool onCooldown;
    public float cooldownTime;

    public float blinkDistance;

    public PlayerController player;

    public LayerMask wallsMask;

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (onCooldown == true)
        {
            timer += Time.deltaTime;
            if (timer >= cooldownTime)
            {
                timer = 0;
                onCooldown = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (onCooldown == false && player.dir != Vector2.zero && player.blockMovement == false )
            {
                Vector2 blinkDir = player.dir * blinkDistance;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, blinkDir, blinkDistance + 1, wallsMask);
                if(hit.collider != null)
                {
                    blinkDir = player.dir * (hit.distance - 1);
                }
                player.transform.position += (Vector3)blinkDir;


                onCooldown = true;
            }
        }


    }
}
