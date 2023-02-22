using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui : MonoBehaviour
{
    public static Ui instance;
    public bool isInInventory = false;
    BuildManager bm;
    WaveSpawner spawner;
    GameObject waveButton;

    public TextMeshProUGUI money;
    [Header("Wave Images")]
    public Sprite waveStartButton;
    public Sprite midWaveButton;

    [Header("Icons")]
    public Sprite normalTurretSprite;
    public Sprite fastTurretSprite;

    [Header("Prefabs")]
    public Transform Inventory;
    public GameObject TurretUi;
    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        bm = BuildManager.instance;
        spawner = WaveSpawner.instance;
        waveButton = GameObject.Find("StartWave");
        LoadTurrets();
    }
    private void Update()
    {
        SetMoney();
        if (spawner.spawning)
        {
            waveButton.GetComponent<Image>().sprite = midWaveButton;
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies != null && enemies.Length > 0)
        {
            waveButton.GetComponent<Image>().sprite = midWaveButton;
            return;
        }
        waveButton.GetComponent<Image>().sprite = waveStartButton;
    }

    private void SetMoney()
    {
        if (money == null)
        {
            money.SetText("$0");
            return;
        }
        money.SetText("$" + Player.instance.money);
    }

    public void startWave()
    {
        if (spawner.spawning)
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null && enemies.Length > 0) 
        { 
            return;
        }
        spawner.StartWave();
        spawner.spawning = true;
    }
    public void selectTurret(TowerItem tower)
    {
        bm.changeTurret(tower);
    }

    public void LoadTurrets()
    {
        foreach(var ui in GameObject.FindGameObjectsWithTag("TurretUI"))
        {
            Destroy(ui.gameObject);
        }
        if (isInInventory)
        {
            BaseInventory.Instance.LoadItems();
        }
        LoadItems();
    }

    public void LoadItems()
    {
        foreach (TowerItem tower in Player.instance.towers)
        {
            GameObject newUiTower = Instantiate(TurretUi);
            newUiTower.transform.SetParent(Inventory);

            newUiTower.transform.GetChild(0).GetComponent<UiElement>().item = tower;

            Button button = newUiTower.transform.GetChild(0).GetComponent<Button>();
            button.onClick.AddListener(delegate {
                if (!Game.instance.playing)
                {
                    return;
                }

                selectTurret(tower); 
            });

            Image rarity = newUiTower.GetComponent<Image>();
            Image icon = newUiTower.transform.GetChild(0).GetComponent<Image>();

            SetUISprite(tower, icon);
            SetRarityColor(tower, rarity);
        }

    }
    private void SetRarityColor(TowerItem tower, Image rarity)
    {
        switch (tower.rarity)
        {
            case 1:
                rarity.color = Color.gray;
                break;
            case 2:
                rarity.color = Color.yellow;
                break;
            case 3:
                rarity.color = Color.magenta;
                break;
            default:
                rarity.color = Color.white;
                break;
        }
    }

    private void SetUISprite(TowerItem tower, Image icon)
    {
        switch (tower.towerType)
        {
            case "normal":
                icon.sprite = normalTurretSprite;
                break;
            case "fast":
                icon.sprite = fastTurretSprite;
                break;
        }
    }
}
