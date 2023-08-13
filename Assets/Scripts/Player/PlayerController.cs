using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region
    public static PlayerController ins;
    public void Awake()
    {
        ins = this;
    }
    #endregion
    [Header("References")]
    public PlayerStats stats;
    public Animator animator;
    public Transform sword;
    public Rigidbody2D rb;
    public AudioSource audioSource;
    public PlayerUIController ui;

    [Header("Data")]
    public Vector2 dir;
    public float moveSpeed;
    public bool blockMovement;
    public bool isInvulnerable;
    float blend = 0; // animations

    [Header("Damage Colors")]
    public SpriteRenderer bodySprite;
    public Color originalColor;
    public Color hurtColor;
    float hurtTimer;
    public float hurtTimerMax;
    public bool recentlyHurt;

    [Header("Audio")]
    public AudioClip soundSwordSlash;
    public AudioClip soundPlayerHurt;


    Vector2 last_beforezero;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource.volume = SoundManager.ins.soundsVolume;
        ui = GetComponent<PlayerUIController>();
    }


    private void Update()
    {
        //playerInput(); // Attacks "on itself" when standing still
        //playerInput2(); // Only 4 directions attack
        playerInput3(); // 8 directions attack

        ColorChangeOnDamage();
    }

    void playerInput()
    {
        dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            blend = 0.6f;
            //animator.SetFloat("Blend", 0.6f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            blend = 1;
            //animator.SetFloat("Blend", 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            blend = 0.3f;
            //animator.SetFloat("Blend", 0.3f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            blend = 0;
            //animator.SetFloat("Blend", 0);
        }

        dir.Normalize();

        if (blockMovement)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        sword.localPosition = new Vector3(dir.x, dir.y, 0);
        animator.SetFloat("Blend", blend);

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            animator.SetBool("IsMoving", false);
            rb.velocity = Vector2.zero;
            blockMovement = true;
            return;
        }

        animator.SetBool("IsMoving", dir.magnitude > 0);

        rb.velocity = moveSpeed * dir;
    }
    void playerInput2()
    {
        dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            blend = 0.6f;
            //animator.SetFloat("Blend", 0.6f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            blend = 1;
            //animator.SetFloat("Blend", 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            blend = 0.3f;
            //animator.SetFloat("Blend", 0.3f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            blend = 0;
            //animator.SetFloat("Blend", 0);
        }

        dir.Normalize();

        if (blockMovement)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        animator.SetFloat("Blend", blend);

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            animator.SetBool("IsMoving", false);
            rb.velocity = Vector2.zero;
            blockMovement = true;

            if (dir != Vector2.zero)
            {
                if (dir.y != 0)
                {
                    dir.x = 0;
                }
                sword.localPosition = new Vector3(dir.x, dir.y, 0);
                sword.localPosition *= 0.6f;
            }
            //Debug.Break();
            return;
        }


        animator.SetBool("IsMoving", dir.magnitude > 0);
        //Debug.Log(dir.magnitude);

        rb.velocity = moveSpeed * dir;

        
    }
    void playerInput3()
    {
        dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            blend = 0.6f;
            //animator.SetFloat("Blend", 0.6f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            blend = 1;
            //animator.SetFloat("Blend", 1);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            blend = 0.3f;
            //animator.SetFloat("Blend", 0.3f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            blend = 0;
            //animator.SetFloat("Blend", 0);
        }

        dir.Normalize();

        if (blockMovement)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if(dir != Vector2.zero)
        {
            last_beforezero = dir;
        }

        animator.SetFloat("Blend", blend);

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            animator.SetBool("IsMoving", false);
            rb.velocity = Vector2.zero;
            blockMovement = true;

            if (dir != Vector2.zero)
            {
                sword.localPosition = new Vector3(dir.x, dir.y, 0);
            }
            else
            {
                sword.localPosition = last_beforezero;
            }

            return;
        }


        animator.SetBool("IsMoving", dir.magnitude > 0);
        //Debug.Log(dir.magnitude);

        rb.velocity = moveSpeed * dir;

        
    }

    public void ANIM_EndAttack()
    {
        blockMovement = false;
    }
    public void TakeDamage(float val)
    {
        if(isInvulnerable == true)
        {
            return;
        }
        stats.TakeDamage(val);
        hurtTimer = 0;
        recentlyHurt = true;
        audioSource.PlayOneShot(soundPlayerHurt);
    }

    void ColorChangeOnDamage()
    {
        if(recentlyHurt == true)
        {
            hurtTimer += Time.deltaTime;
            bodySprite.color = Color.Lerp(hurtColor, originalColor, hurtTimer);

            if(hurtTimer >= hurtTimerMax)
            {
                hurtTimer = 0;
                recentlyHurt = false;
                bodySprite.color = originalColor;
            }
        }
    }

    public void ANIM_PlaySound()
    {
        audioSource.PlayOneShot(soundSwordSlash);
    }
}
