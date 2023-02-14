using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseInventory : MonoBehaviour
{
    public static BaseInventory Instance;
    [Header("Icons")]
    public Sprite normalTurretSprite;
    public Sprite fastTurretSprite;

    [Header("Prefabs")]
    public Transform Inventory;
    public GameObject TurretUi;
    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void ShowInventory()
    {
        this.gameObject.SetActive(true);
    }
    public void HideInventory()
    {
        this.gameObject.SetActive(false);
    }
    public void LoadInventory()
    {
        foreach (var ui in GameObject.FindGameObjectsWithTag("TurretUI"))
        {
            Destroy(ui.gameObject);
        }
        foreach (TowerItem tower in Player.instance.towers)
        {
            GameObject newUiTower = Instantiate(TurretUi);
            newUiTower.transform.SetParent(Inventory);

            newUiTower.transform.GetChild(0).GetComponent<UiElement>().item = tower;

            Button button = newUiTower.transform.GetChild(0).GetComponent<Button>();
            //button.onClick.AddListener(delegate { selectTurret(tower); });

            Image rarity = newUiTower.GetComponent<Image>();
            Image icon = newUiTower.transform.GetChild(0).GetComponent<Image>();
            switch (tower.towerType)
            {
                case "normal":
                    icon.sprite = normalTurretSprite;
                    break;
                case "fast":
                    icon.sprite = fastTurretSprite;
                    break;
            }
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

}
