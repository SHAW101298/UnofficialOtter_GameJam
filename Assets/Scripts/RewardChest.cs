using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardChest : MonoBehaviour
{
    public Reward_Base reward;
    float timer;
    [SerializeField] BoxCollider2D trigCollider;

    public void GivePlayerReward()
    {
        reward.ApplyReward();
        GameController.ins.ChangeState(ENUM_CurrentGameState.rewardChoosen);
        Destroy(gameObject);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        

        if(timer > 1)
        {
            trigCollider.enabled = true;
        }
    }
}
