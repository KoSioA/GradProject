using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    List<IItem> inventory;
    private void Awake()
    {
        inventory = new List<IItem> { new TowerItem(1, "normal", 1f, 1f, 10f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(2, "normal", 1f, 1f, 10f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(1, "fast", 1f, 10f, 5f),
            new TowerItem(3, "normal", 1f, 1f, 10f) };
    }
    private void OnMouseDown()
    {
        BaseInventory.Instance.ShowInventory();
    }
    private void OnMouseEnter()
    {
        ToolTip.ShowToolTipStatic(inventory.Count.ToString());
    }
    private void OnMouseExit()
    {
        ToolTip.HideToolTipStatic();
    }
}
