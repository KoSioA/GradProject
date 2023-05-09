using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropOnly : MonoBehaviour, IDropHandler
{
    private const string invContent = "InventoryContent";
    private const string baseContent = "BaseContent";
    private const string upgradeContent = "Upgrades";
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DROP");
        Transform dropppedObject = eventData.pointerDrag.transform;
        if (eventData.pointerDrag.GetComponent<UiElement>().item == null)
        {
            return;
        }
        IItem item = eventData.pointerDrag.GetComponent<UiElement>().item;
        switch (this.transform.name)
        {
            case invContent:
                Debug.Log("DroppingOnInv");
                if (dropppedObject.GetComponent<UiElementDragAndDrop>().oldParent.name == invContent)
                {
                    Debug.Log("Old Parent Identical");
                    break;
                }
                Debug.Log("Adding");
                Detach(item);
                Player.instance.inventory.Add(item);
                break;
        }
        UpgradeWindow.instance.UpdateWithoutOpening();
        Ui.instance.LoadTurrets();
    }
    private void Detach(IItem item)
    {
        if (Player.instance.inventory.Contains(item))
        {
            Player.instance.inventory.Remove(item);
        }
        if (BaseScript.instance.inventory.Contains(item))
        {
            BaseScript.instance.inventory.Remove(item);
        }
        if (item.type != "upgrade")
        {
            return;
        }
        for (int i = 0; i < UpgradeWindow.instance.tower.upgrades.Length; i++)
        {
            UpgradeItem upgrade = UpgradeWindow.instance.tower.upgrades[i];
            if (upgrade == (UpgradeItem)item)
            {
                upgrade = null;
            }
        }
    }
}
