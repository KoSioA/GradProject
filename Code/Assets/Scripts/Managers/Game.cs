using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game instance;
    public bool playing = false;
    private void Awake()
    {
        instance = this;
    }
    public void LoseGame()
    {
        playing = false;
        GameMenu.instance.OpenLoseScreen();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (this.playing)
            {
                this.PauseGame();
                return;
            }
            this.UnPauseGame();
        }
    }
    public void PauseGame()
    {
        this.playing = false;
        GameMenu.instance.OpenPauseScreen();
    }
    public void UnPauseGame()
    {
        this.playing = true;
        GameMenu.instance.CloseScreen();
    }
    public void RestartGame()
    {
        this.playing = true;
        Player.instance.Reset();
        GameMenu.instance.CloseScreen();
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Assets/Scenes/MainMenu.unity");
    }
}
