using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_CurrentGameState
{
    spawningRewards,
    rewardChoosen,
    beginNextWave
}

public class GameController : MonoBehaviour
{
    public static GameController ins;
    public ENUM_CurrentGameState gameState;

    [SerializeField]
    public List<Reward_Base> rewards;
    public List<Reward_Base> copy;
    public GameObject rewardPrefab;
    public Transform rewardSpawnPosition;

    public bool run;
    // Start is called before the first frame update
    void Start()
    {
        ins = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            ProceedWithState();
            run = false;
        }

    }
    public void ChangeState(ENUM_CurrentGameState newState)
    {
        gameState = newState;
        ProceedWithState();
    }
    void ProceedWithState()
    {
        switch (gameState)
        {
            case ENUM_CurrentGameState.spawningRewards:
                SpawnRewards();
                break;

            case ENUM_CurrentGameState.rewardChoosen:
                RewardChoosen();
                break;

            case ENUM_CurrentGameState.beginNextWave:
                BeginNextWave();
                break;
        }
    }
    void SpawnRewards()
    {
        foreach (Reward_Base reward in rewards)
        {
            copy.Add(reward);
        }
        int rand;
        Reward_Base reward1, reward2, reward3;
        rand = Random.Range(0, copy.Count);
        reward1 = copy[rand];
        copy.RemoveAt(rand);

        rand = Random.Range(0, copy.Count);
        reward2 = copy[rand];
        copy.RemoveAt(rand);

        rand = Random.Range(0, copy.Count);
        reward3 = copy[rand];
        copy.RemoveAt(rand);

        copy.Clear();

        GameObject temp = Instantiate(rewardPrefab, rewardSpawnPosition);
        temp.transform.position = rewardSpawnPosition.position + new Vector3(-2.5f, 0, 0);
        temp.GetComponent<RewardChest>().reward = reward1;

        temp = Instantiate(rewardPrefab, rewardSpawnPosition);
        temp.transform.position = rewardSpawnPosition.position;
        temp.GetComponent<RewardChest>().reward = reward2;

        temp = Instantiate(rewardPrefab, rewardSpawnPosition);
        temp.transform.position = rewardSpawnPosition.position + new Vector3(2.5f, 0, 0);
        temp.GetComponent<RewardChest>().reward = reward3;

        PlayerController.ins.stats.HealPlayerCompletely();

        MessageController.ins.ShowTimedMessage("Walk towards the chests and claim your reward");
        //MessageController.ins.nextWaveText.text = "Walk towards the chests and claim your reward";
    }
    void RewardChoosen()
    {
        foreach(Transform child in rewardSpawnPosition.transform)
        {
            Destroy(child.gameObject);
        }
        PlayerController.ins.stats.MaxHealthShieldUpdate();
        
        MessageController.ins.ShowTimedMessage("Stand on the altar in the center of the map");
    }
    void BeginNextWave()
    {
        WaveManager.ins.CreateNextWave();
        MessageController.ins.HideNextWaveMessage();
    }
    
}

