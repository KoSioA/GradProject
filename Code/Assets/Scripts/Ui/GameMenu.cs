using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public static GameMenu instance;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private Transform ScoreText;
    private void Awake()
    {
        instance = this;
        this.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        WinPanel.SetActive(false);
    }
    public void OpenLoseScreen()
    {
        this.gameObject.SetActive(true);
        gameOverPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void WinGame()
    {
        this.gameObject.SetActive(true);
        ScoreText.GetComponent<TextMeshProUGUI>().SetText("Score: " + Player.instance.money);
        WinPanel.SetActive(true);
    }
    public void OpenPauseScreen()
    {
        this.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void CloseScreen()
    {
        this.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        WinPanel.SetActive(false);
    }
}
