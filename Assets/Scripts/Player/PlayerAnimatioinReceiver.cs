using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatioinReceiver : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void ANIM_AttackEnd()
    {
    }
}
