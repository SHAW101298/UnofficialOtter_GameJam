using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardInfoCollider : MonoBehaviour
{
    public RewardChest reward;

    bool playerInCircle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name + " entered collision area");
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInCircle = true;
            MessageController.ins.ShowRewardWindow(reward);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInCircle = false;
            MessageController.ins.HideRewardWindow();
        }
    }

    private void Update()
    {
        if(playerInCircle == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                reward.GivePlayerReward();
            }
        }
    }
}
