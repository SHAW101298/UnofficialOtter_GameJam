using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerUIController : MonoBehaviour
{
    PlayerController player;
    public Slider musicSlider;
    public Slider soundSlider;

    public GameObject pauseWindow;
    public GameObject optionsWindow;
    public GameObject helpWindow;
    [Header("Statystyki")]
    public GameObject statsWindow;
    public Text healthField;
    public Text shieldField;
    public Text damageField;
    public Text critChanceField;
    public Text critDamageField;
    public Text moveSpeedField;


    private void Start()
    {
        player = GetComponent<PlayerController>();
        musicSlider.value = SoundManager.ins.musicVolume;
        soundSlider.value = SoundManager.ins.soundsVolume;
    }
    public void MusicVolumeChanged(Slider slider)
    {
        SoundManager.ins.ChangeMusicVolume(slider);
    }
    public void SoundVolumeChanged(Slider slider)
    {
        SoundManager.ins.ChangeSoundVolume(slider);
        player.audioSource.volume = slider.value;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseWindow.SetActive(!pauseWindow.activeSelf);
            optionsWindow.SetActive(false);
            helpWindow.SetActive(false);
            statsWindow.SetActive(false);

            if(pauseWindow.activeSelf == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            helpWindow.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            UpdateStatsFields();
            statsWindow.SetActive(true);
        }
    }

    public void ShowOptionsMenu()
    {
        optionsWindow.SetActive(true);
    }
    public void HideOptionsMenu()
    {
        optionsWindow.SetActive(false);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
    public void ShowHelpWindow()
    {
        helpWindow.SetActive(true);
    }

    void UpdateStatsFields()
    {
        healthField.text = player.stats.maxHealth.ToString();
        shieldField.text = player.stats.maxShield.ToString();
        damageField.text = player.stats.damage.ToString();
        critChanceField.text = player.stats.critChance.ToString();
        critDamageField.text = player.stats.critDamage.ToString();
        moveSpeedField.text = player.moveSpeed.ToString();
    }
}
