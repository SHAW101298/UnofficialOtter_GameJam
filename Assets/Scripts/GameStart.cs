using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject optionsWindow;
    

    public void BTN_StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void BTN_Options()
    {
        optionsWindow.SetActive(true);
    }
    public void BTN_Return()
    {
        optionsWindow.SetActive(false);
    }

    public void BTN_ExitGame()
    {
        Application.Quit();
    }
    
}
