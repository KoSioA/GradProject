using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    BuildManager bm;
    WaveSpawner spawner;
    GameObject waveButton;

    [Header("Wave Images")]
    public Sprite waveStartButton;
    public Sprite midWaveButton;
    private void Start()
    {
        bm = BuildManager.instance;
        spawner = WaveSpawner.instance;
        waveButton = GameObject.Find("StartWave");
    }
    private void Update()
    {
        if (spawner.spawning)
        {
            waveButton.GetComponent<Image>().sprite = midWaveButton;
            return;
        }
        waveButton.GetComponent<Image>().sprite = waveStartButton;
    }
    public void startWave()
    {
        spawner.StartWave();
    }
    public void selectNormalTurret()
    {
        bm.changeTurret(bm.normalTurret);
    }
    public void selectFastTurret()
    {
        bm.changeTurret(bm.fastTurret);
    }
    public void selectSomeTurret(int i)
    {
        bm.changeTurret(bm.fastTurret);
    }
}
