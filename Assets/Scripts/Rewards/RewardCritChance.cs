using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CritChance", menuName = "Custom/Reward/CritChance")]
public class RewardCritChance : Reward_Base
{
    public int critChanceAmount;
    public override void ApplyReward()
    {
        PlayerStats stats = PlayerController.ins.stats;
        stats.critChance += critChanceAmount;
    }
}
