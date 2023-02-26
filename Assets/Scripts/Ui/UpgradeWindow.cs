using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeWindow : MonoBehaviour
{
    public static UpgradeWindow instance;
    private TowerItem tower;
    public TextMeshProUGUI statsText;

    public GameObject UIPrefab;
    public Sprite upgradeIcon;
    public Transform upgradeView;
    public Color emptyUpgradeColor;
    private void Awake()
    {
        instance = this;
        this.gameObject.SetActive(false);
    }
    public void OpenWindow(TowerItem newTower)
    {
        this.tower = newTower;
        UpdateWindow();
    }
    public void UpdateWindow()
    {
        UpdateStats();
        UpdateUpgrades();
    }
    private void UpdateStats()
    {
        this.gameObject.SetActive(true);
        var towerStats = tower.getStats();
        string stats = $"{tower.towerType} tower\n" +
                        $"Damage: {towerStats["damage"]}\n" +
                        $"Range: {towerStats["range"]}\n" +
                        $"Fire Rate: {towerStats["fireRate"]}\n" + 
                        $"Rarity: {this.tower.rarity}";
        this.statsText.SetText(stats);
    }
    private void UpdateUpgrades()
    {
        foreach (var ui in GameObject.FindGameObjectsWithTag("TurretUI"))
        {
            if (ui.transform.parent == this.upgradeView)
            {
                Destroy(ui.gameObject);
            }
        }
        foreach (var upgrade in this.tower.upgrades)
        {
            GameObject current = Instantiate(UIPrefab);
            current.transform.SetParent(upgradeView);
            if(upgrade == null)
            {
                current.GetComponent<Image>().color = emptyUpgradeColor;
                current.transform.GetChild(0).GetComponent<UiElement>().item = UpgradeItem.EmptyItem;
                current.transform.GetChild(0).GetComponent<Image>().sprite = null;
                continue;
            }
            current.transform.GetChild(0).GetComponent<UiElement>().item = upgrade;
            SetRarityColor(upgrade, current.GetComponent<Image>());
            current.transform.GetChild(0).GetComponent<Image>().sprite = upgradeIcon;

        }
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
    private void SetRarityColor(IItem tower, Image rarity)
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
}
