using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public List<IItem> inventory;
    public static BaseScript instance;
    private void Awake()
    {
        instance = this;
        inventory = new List<IItem> { new TowerItem(1, "normal", 1f, 1f, 10f) };
    }
    public void AddItem(IItem item)
    {
        inventory.Add(item);
        if(Ui.instance.isInInventory == false)
        {
            return;
        }
        BaseInventory.Instance.LoadInventory();
    }
    private void OnMouseDown()
    {
        BuildManager.instance.selectedTurret = null;
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
