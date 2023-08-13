using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Custom/Reward/Shield")]
public class RewardShield : Reward_Base
{
    public float shieldAmount;
    public override void ApplyReward()
    {
        PlayerStats stats = PlayerController.ins.stats;
        stats.shield += shieldAmount;
        stats.maxShield += shieldAmount;
    }
}
