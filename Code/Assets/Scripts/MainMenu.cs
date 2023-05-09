using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject helpTab;
    private void Awake()
    {
        HideHelp();
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Assets/Scenes/LevelScene.unity");
    }

    public void HideHelp()
    {
        helpTab.SetActive(false);
    }

    public void ShowHelp()
    {
        helpTab.SetActive(true);
    }
}
