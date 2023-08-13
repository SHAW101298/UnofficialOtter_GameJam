using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    PlayerController player;
    public float maxHealth;
    public float health;

    public float shield;
    public float maxShield;

    public float damage;
    public int critChance = 5;
    public float critDamage = 2;
    [Header("timer")]
    public bool regenerateShield;
    public float shieldTimer;
    public float shieldRegenerationTime;
    [Header("Bars")]
    public Image healthBar;
    public Image shieldBar;
    [Header("BG")]
    public Image healthBG;
    public Image shieldBG;

    // BUFFS
    //public float bonusDamage;
    //public float bonusCritChance;


    private void Start()
    {
        player = GetComponent<PlayerController>();
        MaxHealthShieldUpdate();
    }
    public void TakeDamage(float amount)
    {
        shieldTimer = 0;
        regenerateShield = true;

        float currentshield = shield;
        float leftover_damage = amount;

        shield -= leftover_damage;
        leftover_damage -= currentshield;

        if (shield < 0)
        {
            shield = 0;
            health -= leftover_damage;
            if (health <= 0)
            {
                maxHealth += health; // dodaje ujemne zdrowie 
                health = 0;

                if (maxHealth <= 0)
                {
                    MessageController.ins.ShowGameOverWindow();
                    player.blockMovement = true;
                    Time.timeScale = 0;
                    //Debug.Log("Player dead");
                }
            }
        }
        MaxHealthShieldUpdate();
    }

    void UIHealthUpdate()
    {
        float healthAmount = health / maxHealth;

        shieldBar.fillAmount = shield / maxShield;
        healthBar.fillAmount = healthAmount;
    }

    private void Update()
    {
        ShieldRegeneration();
    }

    public float ReadDamage()
    {
        float dmg = damage;

        if(critChance > 100)
        {
            dmg *= critDamage;
            int rand = Random.Range(100, 200);
            if (rand <= critChance)
            {
                dmg *= critDamage;
            }
            return dmg;
        }
        else
        {
            int rand = Random.Range(0, 100);
            if (rand <= critChance)
            {
                dmg *= critDamage;
            }
            return dmg;
        }

        
    }
    void ShieldRegeneration()
    {
        if(regenerateShield == true)
        {
            shieldTimer += Time.deltaTime;
            if (shieldTimer >= shieldRegenerationTime)
            {
                shield = maxShield;
                shieldTimer = 0;
                regenerateShield = false;
                UIHealthUpdate();
            }
        }
    }
    public void MaxHealthShieldUpdate()
    {
        float healthWidth = maxHealth * 10;
        float shieldWidth = maxShield * 10;
        //Debug.Log("HealthWidth = " + healthWidth);
        //Debug.Log(healthBar.GetComponent<RectTransform>().sizeDelta);
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(healthWidth, 25);
        //Debug.Log(healthBar.GetComponent<RectTransform>().sizeDelta);
        healthBG.GetComponent<RectTransform>().sizeDelta = new Vector2(healthWidth, 25);
        shieldBar.GetComponent<RectTransform>().sizeDelta = new Vector2(shieldWidth, 25);
        shieldBG.GetComponent<RectTransform>().sizeDelta = new Vector2(shieldWidth, 25);
        //Debug.Log(healthBar.GetComponent<RectTransform>().sizeDelta);
        UIHealthUpdate();
    }

    public void HealPlayerCompletely()
    {
        health = maxHealth;
        shield = maxShield;
        UIHealthUpdate();
    }
}
