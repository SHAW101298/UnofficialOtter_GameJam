using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPointController : MonoBehaviour
{
    bool playerInCircle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnNewWave();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(WaveManager.ins.isActiveWave == false)
            {
                playerInCircle = true;
                MessageController.ins.ShowNextWaveMessage();
                if(GameController.ins.gameState == ENUM_CurrentGameState.spawningRewards)
                {
                    MessageController.ins.nextWaveText.text = "Collect reward from one chest";
                }
                else
                {
                    MessageController.ins.nextWaveText.text = "Press F to begin next wave";
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (WaveManager.ins.isActiveWave == false)
            {
                playerInCircle = false;
                MessageController.ins.HideNextWaveMessage();
            }
        }
    }
    
    void SpawnNewWave()
    {
        if (GameController.ins.gameState != ENUM_CurrentGameState.rewardChoosen)
            return;
        if (playerInCircle == false)
            return;
        if(Input.GetKeyDown(KeyCode.F))
        {
            GameController.ins.ChangeState(ENUM_CurrentGameState.beginNextWave);
        }
    }
}
