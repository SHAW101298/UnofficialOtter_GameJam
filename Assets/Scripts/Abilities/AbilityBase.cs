using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityBase : MonoBehaviour
{
    protected PlayerController player;

    public string abilityName;
    public string description;

    protected float timer;
    public bool onCooldown;
    public float cooldownTime;

    public Image icon;

    public void Recharge()
    {
        if (onCooldown == true)
        {
            icon.fillAmount = timer / cooldownTime;
            timer += Time.deltaTime;
            if (timer >= cooldownTime)
            {
                timer = 0;
                icon.fillAmount = 1;
                onCooldown = false;
            }
        }
    }
}
