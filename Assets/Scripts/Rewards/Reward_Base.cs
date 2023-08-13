using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[SerializeField]
public abstract class Reward_Base : ScriptableObject
{
    public string rewardName;
    public string rewardDescription;
    public abstract void ApplyReward();
}
