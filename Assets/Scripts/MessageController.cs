using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MessageController : MonoBehaviour
{
    public static MessageController ins;
    public GameObject nextWaveWindow;
    public TextMeshProUGUI nextWaveText;
    [Space(10)]
    public float timer;
    public bool hideTimeddWindow;
    public float timeToHideMessages;
    [Space(10)]
    public GameObject rewardWindow;
    public TextMeshProUGUI rewardText;
    [Space(10)]
    public GameObject gameOverWindow;
    public TextMeshProUGUI gameOverText;
    [Space(10)]
    public GameObject timedWindow;
    public TextMeshProUGUI timedText;
    [Space(10)]
    public GameObject gameCompletedWindow;


    private void Start()
    {
        ins = this;
    }

    public void ShowNextWaveMessage()
    {
        nextWaveWindow.SetActive(true);
        
    }
    public void HideNextWaveMessage()
    {
        nextWaveWindow.SetActive(false);
    }
    private void Update()
    {
        HideTimedMessageCountDown();
    }
    void HideTimedMessageCountDown()
    {
        if (hideTimeddWindow == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeToHideMessages)
            {
                timer = 0;
                hideTimeddWindow = false;
                HideTimedMessage();
            }
        }
    }

    public void ShowRewardWindow(RewardChest reward)
    {
        rewardText.text = reward.reward.rewardDescription;
        rewardWindow.SetActive(true);
    }
    public void HideRewardWindow()
    {
        rewardWindow.SetActive(false);
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
        gameOverText.text = ("You managed to beat " + (WaveManager.ins.currentWave) + " waves");
    }

    public void ShowTimedMessage(string text)
    {
        timedText.text = text;
        timer = 0;
        hideTimeddWindow = true;
        timedWindow.SetActive(true);
    }
    public void HideTimedMessage()
    {
        timedWindow.SetActive(false);
        hideTimeddWindow = false;
        timer = timeToHideMessages;
    }

    public void ShowGameCompletedWindow()
    {
        gameCompletedWindow.SetActive(true);
    }
    
}
