using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeed", menuName = "Custom/Reward/MoveSpeed")]
public class RewardMoveSpeed : Reward_Base
{
    public float moveSpeedAmount;
    public override void ApplyReward()
    {
        PlayerController.ins.moveSpeed += moveSpeedAmount;
    }
}
