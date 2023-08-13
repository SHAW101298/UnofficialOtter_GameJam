using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CritDamage", menuName = "Custom/Reward/CritDamage")]
public class RewardCritDamage : Reward_Base
{
    public float critDamageAmount;
    public override void ApplyReward()
    {
        PlayerStats stats = PlayerController.ins.stats;
        stats.critDamage += critDamageAmount;
        UpdateChanges();
    }
}
