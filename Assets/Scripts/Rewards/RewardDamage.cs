using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Custom/Reward/Damage")]
public class RewardDamage : Reward_Base
{
    public float damageAmount;
    public override void ApplyReward()
    {
        PlayerStats stats = PlayerController.ins.stats;
        stats.damage += damageAmount;
        UpdateChanges();
    }
}
