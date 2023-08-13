using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Custom/Reward/Health")]
public class RewardHealth : Reward_Base
{
    public float healthAmount;
    public override void ApplyReward()
    {
        PlayerStats stats = PlayerController.ins.stats;
        stats.health += healthAmount;
        stats.maxHealth += healthAmount;
        UpdateChanges();
    }
}
