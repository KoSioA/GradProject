using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseInventory : MonoBehaviour
{
    public static BaseInventory instance;
    [Header("Icons")]
    public Sprite normalTurretSprite;
    public Sprite fastTurretSprite;
    public Sprite upgradeSprite;

    [Header("Prefabs")]
    public Transform Inventory;
    public GameObject TurretUi;

    private void Awake()
    {
        instance = this;
        this.gameObject.SetActive(false);
    }
    public void ShowInventory()
    {
        this.gameObject.SetActive(true);
        Ui.instance.isInInventory = true;
        LoadInventory();
    }
    public void HideInventory()
    {
        this.gameObject.SetActive(false);
        Ui.instance.isInInventory = false;
    }
    public void LoadInventory()
    {
        foreach (var ui in GameObject.FindGameObjectsWithTag("TurretUI"))
        {
            if(ui.transform.parent.name == "BaseContent")
            {
                Destroy(ui.gameObject);
            }
        }
        LoadItems();
    }

    public void LoadItems()
    {
        foreach (IItem item in BaseScript.instance.inventory)
        {
            /*TowerItem tower = (TowerItem)item;
            GameObject newUiTower = Instantiate(TurretUi);
            newUiTower.transform.SetParent(Inventory);

            newUiTower.transform.GetComponent<UiElement>().item = tower;

            Button button = newUiTower.transform.GetChild(0).GetComponent<Button>();

            Image rarity = newUiTower.GetComponent<Image>();
            Image icon = newUiTower.transform.GetChild(0).GetComponent<Image>();

            SetUISprite(tower, icon);

            SetRarityColor(tower, rarity);*/
            GameObject newUiTower = Instantiate(TurretUi);
            newUiTower.transform.SetParent(Inventory);

            newUiTower.transform.GetComponent<UiElement>().item = item;


            Image rarity = newUiTower.GetComponent<Image>();
            Image icon = newUiTower.transform.GetChild(0).GetComponent<Image>();

            SetUISprite(item, icon);
            SetRarityColor(item, rarity);
        }
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

    private void SetUISprite(IItem item, Image icon)
    {
        if (item.type == "upgrade")
        {
            icon.sprite = upgradeSprite;
            return;
        }
        TowerItem tower = (TowerItem)item;
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
